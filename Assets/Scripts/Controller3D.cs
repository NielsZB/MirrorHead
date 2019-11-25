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

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";

    public GameObject mirror;

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

            float moveHorizontal = Input.GetAxis(horizontalCtrl);
            float moveVertical = Input.GetAxis("Vertical");

            rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

            // if (Input.GetButtonDown("Jump") && isGrounded == true)
            // {
            //     rb.AddForce(new Vector3(0, 5f, 0) * jumpSpeed, ForceMode.Impulse);
            //     isGrounded = false;
            // }

            if (Input.GetAxis(jumpButton) != 0 && isGrounded == true)
            {
                rb.AddForce(new Vector3(0, 5f, 0) * jumpSpeed, ForceMode.Impulse);
                isGrounded = false;
            }

                     
        

            mirror.transform.position = transform.position;

        //sound - int i = Random.Range(0,jumpClips.Length);
        //AudioSource.PlayClipAtPoint((whateveraudiois),transform.position);
        }
}


 

