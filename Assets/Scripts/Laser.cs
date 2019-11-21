using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Ray ray;
    bool hitNonReflectiveObject;
    private void Start()
    {
        ray = new Ray(transform.position, transform.up);
    }

    private void Update()
    {
        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            if(hit.transform.CompareTag("Reflection"))
            {

            }
        }

        while(calculatingRays)
        {
            Vector3 point;
            Vector3 direction;

            if(Physics.)
        }
    }
}
