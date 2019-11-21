using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour

{
    public float turnSpeed = 20f;
    public float speed = 2.0f;
    public float jumpSpeed;
    public bool isGrounded;
    Rigidbody rb;
    Vector3 m_Movement;
    




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)

    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
        
    }


    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0) * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    

}

