using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMirror : MonoBehaviour
{
    public float mirrorSpeed = 2f;
    public string mirrorButton = "Mirror_P1";
    void Start()
    {
       // print(transform.localEulerAngles.x);

    }

        void Update()
    {
        float mirrorRotate = Input.GetAxis(mirrorButton);

        transform.RotateAround(transform.position, (Vector3.forward * mirrorRotate * mirrorSpeed), Time.deltaTime * 90f);
        

     

    }

    // Transform.localEulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 180 / Mathf.PI, 0);
}

