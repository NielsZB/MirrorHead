using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMirror : MonoBehaviour
{
    public float mirrorSpeed = 2f;
    public string mirrorRotateX = "Mirror_P1";
    public string mirrorRotateY = "Mirror_P1";

    float x;
    float y;

    void Update()
    {
        x = Input.GetAxis(mirrorRotateX);
        y = Input.GetAxis(mirrorRotateY);

        //if(x != 0 && y != 0)
        //{
        //    Quaternion
        //    transform.rotation = Quaternion.Slerp()
        //}
        //transform.RotateAround(transform.position, (Vector3.forward * mirrorRotate * mirrorSpeed), Time.deltaTime * 90f);




    }

    // Transform.localEulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 180 / Mathf.PI, 0);
}

