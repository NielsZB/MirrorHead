using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] int maxReflections = 20;
    [SerializeField] float maxDistance = 200f;

    public List<Vector3> Hits { get; private set; } = new List<Vector3>();
    public int MaxReflections { get { return maxReflections; } }

    public Vector3 Origin { get { return transform.position; } }

    public bool IsOn { get; private set; }

    Vector3 previousDirection;

    int _hit;
    int HitCount;

    private void CalculatePath()
    {
        if (previousDirection != transform.right)
        {
            _hit = 0;
            Hits.Capacity = maxReflections;
            LaserPath(transform.position, transform.right, maxReflections);
            HitCount = _hit;
            previousDirection = transform.right;
        }
    }

    private void LaserPath(Vector3 position, Vector3 direction, int remainingReflections)
    {
        if (remainingReflections == 0)
            return;

        _hit++;

        if (Physics.Raycast(position, direction, out RaycastHit hit, maxDistance))
        {
            if (hit.transform.CompareTag("Reflective"))
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;

            }
            else if (hit.transform.CompareTag("Player"))
            {
                Debug.Log($"{hit.transform.name} is dead");
            }
            else
            {
                position = hit.point;
            }

            if (Hits.Count > maxReflections - remainingReflections)
            {
                Hits[maxReflections - remainingReflections] = position;
            }
            else
            {
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

    private void Start()
    {
        Hits.Capacity = maxReflections;
    }

    private void Update()
    {
        if (IsOn)
        {
            CalculatePath();
        }
    }

    private void OnDrawGizmos()
    {
        CalculatePath();

        Gizmos.color = Color.yellow;

        for (int i = 0; i < HitCount; i++)
        {
            if (i == 0)
            {
                Gizmos.DrawLine(Origin, Hits[0]);
            }
            else
            {
                Gizmos.DrawLine(Hits[i - 1], Hits[i]);
            }
        }
    }
}
