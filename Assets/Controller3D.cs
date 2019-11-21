using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour

{
    public float turnSpeed = 20f;
    public float speed = 2.0f;
    Rigidbody rb;
    Vector3 m_Movement;
    




    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
       

    }


}

