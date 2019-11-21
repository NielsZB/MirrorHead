using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] int maxReflections;
    [SerializeField] float maxDistance;

    public List<Vector2> Hits { get; private set; }
    public int MaxReflections { get { return maxReflections; } }

    public Vector2 Origin { get { return transform.position; } }
    private void Start()
    {
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        CalculateReflections(transform.position, transform.right, maxReflections);
    }

    void CalculateReflections(Vector3 position, Vector3 direction, int remainingReflections)
    {
        if (remainingReflections == 0)
            return;

        Vector3 previousPosition = position;

        if (Physics.Raycast(position, direction, out RaycastHit hit, maxDistance))
        {
            if (hit.transform.CompareTag("Reflective"))
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;
            }
            else
            {
                position = hit.point;
            }
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(previousPosition, position);

        if (hit.transform.CompareTag("Reflective"))
        {
            CalculateReflections(position, direction, remainingReflections - 1);

        }
    }


}
