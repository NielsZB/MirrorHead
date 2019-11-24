using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMirror : MonoBehaviour
{
    public float mirrorSpeed = 2f;

    void Start()
    {
       // print(transform.localEulerAngles.x);

    }

        void Update()
    {
        float mirrorRotate = Input.GetAxis("MouseX");

        transform.RotateAround(transform.position, (transform.forward * mirrorRotate * mirrorSpeed), Time.deltaTime * 90f);
        

     

    }

    // Transform.localEulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 180 / Mathf.PI, 0);
}

