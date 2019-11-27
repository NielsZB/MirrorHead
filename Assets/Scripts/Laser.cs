using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    #region Public Variables
    public List<Vector3> Hits { get; private set; } = new List<Vector3>();
    List<Vector3> hitNormals = new List<Vector3>();

    List<LaserParticles> hitParticleSystems = new List<LaserParticles>();
    public int HitCount { get; private set; }

    public int MaxReflections { get { return maxReflections; } }

    public bool IsEnabled { get; private set; }
    #endregion

    #region Private Variables
    [SerializeField] LaserParticles hitParticlePrefab = null;
    [SerializeField] int maxReflections = 20;
    [SerializeField] float maxDistance = 200f;
    [SerializeField] bool EnabledAtStart;
    [SerializeField] LayerMask mask = new LayerMask();
    [SerializeField] bool showDebug = true;

    Vector3 previousDirection;
    int _hit;
    LineRenderer render;
    bool ReflectionChanged;
    #endregion
    public void Activate()
    {
        IsEnabled = true;
    }

    public void Deactivate()
    {
        IsEnabled = false;
    }

    private void Start()
    {
        Hits.Capacity = maxReflections;
        render = GetComponent<LineRenderer>();
        if (EnabledAtStart)
        {
            Activate();
            UpdatePath();
            UpdateVisuals();
        }
    }

    private void Update()
    {
        if (IsEnabled)
        {
            UpdatePath();
            UpdateVisuals();
        }
    }

    void UpdateVisuals()
    {
        if (ReflectionChanged)
        {

            Vector3[] renderPoints = new Vector3[HitCount + 1];

            if (hitParticleSystems.Count > 0)
            {
                for (int i = 0; i < hitParticleSystems.Count; i++)
                {
                    hitParticleSystems[i].Stop();
                    hitParticleSystems.Remove(hitParticleSystems[i]);
                }
            }
            for (int i = 0; i < HitCount + 1; i++)
            {

                if (i == 0)
                {
                    renderPoints[i] = transform.position;
                }
                else
                {
                    renderPoints[i] = Hits[i - 1];

                }

                if (i < HitCount)
                {
                    LaserParticles hitParticles = Instantiate(hitParticlePrefab);
                    
                    hitParticles.SetHitSystem(Hits[i],hitNormals[i]);
                    hitParticleSystems.Add(hitParticles);
                }

            }

            render.positionCount = renderPoints.Length;

            render.SetPositions(renderPoints);

            ReflectionChanged = false;
        }
    }

    private void UpdatePath()
    {
        _hit = 0;
        LaserPath(transform.position, transform.right, maxReflections);
        HitCount = _hit;
    }

    private void LaserPath(Vector3 position, Vector3 direction, int remainingReflections)
    {
        if (remainingReflections == 0)
            return;

        _hit++;

        if (Physics.Raycast(position, direction, out RaycastHit hit, maxDistance,mask))
        {
            if(showDebug)
            {
                Debug.Log($"{hit.transform.name} got hit.", hit.transform.gameObject);
            }
            if (hit.transform.CompareTag("Reflective"))
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;
            }
            else
            {
                if (hit.transform.CompareTag("Player") || hit.transform.CompareTag("Destructible") || hit.transform.CompareTag("Receiver"))
                {
                    if (hit.transform.TryGetComponent(out TriggerResponse triggerEvent))
                    {
                        triggerEvent.Activate();
                    }
                }
                position = hit.point;
            }

            int currentReflectionIndex = maxReflections - remainingReflections;

            if (Hits.Count > currentReflectionIndex)
            {
                if (Hits[currentReflectionIndex] != position)
                {
                    ReflectionChanged = true;
                    Hits[currentReflectionIndex] = position;
                    hitNormals[currentReflectionIndex] = hit.normal;
                }
            }
            else
            {
                ReflectionChanged = true;
                hitNormals.Add(hit.normal);
                Hits.Add(position);
            }

            if (hit.transform.CompareTag("Reflective"))
            {

                LaserPath(position, direction, remainingReflections - 1);
            }
        }
        else
        {
            return;
        }
    }



    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            Hits.Capacity = maxReflections;
            UpdatePath();

            Gizmos.color = Color.yellow;
            for (int i = 0; i < HitCount; i++)
            {
                if (i == 0)
                {
                    Gizmos.DrawLine(transform.position, Hits[0]);
                }
                else
                {
                    Gizmos.DrawLine(Hits[i - 1], Hits[i]);
                }
            }
        }
    }
}
