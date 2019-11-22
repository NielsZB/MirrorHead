using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticles : MonoBehaviour
{
    ParticleSystem system;
    public Transform A, B;

    float initialRateOverTimeMultiplier;

    private void Start()
    {
        system = GetComponent<ParticleSystem>();

        var emission = system.emission;

        initialRateOverTimeMultiplier = emission.rateOverTimeMultiplier;
    }

    [ContextMenu("Set")]
    void Set()
    {
        SetParticleSystem(A.position, B.position);
    }

    public void SetParticleSystem(Vector3 positionA, Vector3 positionB)
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
        emission.rateOverTimeMultiplier = shape.radius;
    }
}
