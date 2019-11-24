using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOffsetApply : MonoBehaviour
{
    public Vector3 worldOffset;

    public void LateUpdate()
    {
        transform.position = transform.parent.position + worldOffset;
    }
}

