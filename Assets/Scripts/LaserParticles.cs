using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticles : MonoBehaviour
{
    ParticleSystem system;
    public float emmisionRate;

    private void Start()
    {
        if (system == null)
        {
            system = GetComponent<ParticleSystem>();
        }
    }
  
    public void Stop()
    {
        system.Stop();

        var main = system.main;
        main.loop = false;
    }
    public void SetBeamSystem(Vector3 positionA, Vector3 positionB)
    {

        transform.position = Vector3.Lerp(positionA, positionB, 0.5f);

        Vector3 perpendicularVector = Vector2.Perpendicular(positionA - positionB);

        transform.rotation = Quaternion.FromToRotation(Vector3.up, perpendicularVector);

        if (system == null)
        {
            system = GetComponent<ParticleSystem>();
        }
        var shape = system.shape;
        shape.radius = (positionA - positionB).magnitude / 2;

        var emission = system.emission;
        emission.rateOverTimeMultiplier = emmisionRate * shape.radius;
        system.Play();
    }
    public void SetHitSystem(Vector3 point, Vector3 direction)
    {
        if (system == null)
        {
            system = GetComponent<ParticleSystem>();
        }
        transform.position = point;
        transform.rotation = Quaternion.LookRotation(direction);
        system.Play();
    }
}
