using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour

{
    public float turnSpeed = 20f;
    public float speed = 2.0f;
    public float jumpSpeed = 20f;
    public bool isGrounded;
    Rigidbody rb;
    Vector3 m_Movement;

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";

    public GameObject mirror;

    Vector2 movementInput;
    public LayerMask mask;
    RaycastHit hit;
    bool jumpReset;
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
        movementInput.Set(Input.GetAxis(horizontalCtrl), Input.GetAxis("Vertical"));

        isGrounded = Physics.SphereCast(transform.position, 0.45f, Vector3.down, out hit,0.1f,mask);

        if(Input.GetAxis(jumpButton) > 0.75f)
        {
            jumpReset = true;
        }

        // if (Input.GetButtonDown("Jump") && isGrounded == true)
        // {
        //     rb.AddForce(new Vector3(0, 5f, 0) * jumpSpeed, ForceMode.Impulse);
        //     isGrounded = false;
        // }

        if (Input.GetAxis(jumpButton) != 0 && isGrounded && jumpReset)
        {
            Jump();
            jumpReset = false;
        }




        mirror.transform.position = transform.position;

        //sound - int i = Random.Range(0,jumpClips.Length);
        //AudioSource.PlayClipAtPoint((whateveraudiois),transform.position);
    }

    private void FixedUpdate()
    {
        Vector3 projectedMovement = Vector3.ProjectOnPlane(new Vector3(movementInput.x, 0, 0),hit.normal);
        rb.AddForce(new Vector3(movementInput.x, movementInput.y, 0f) * speed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        isGrounded = false;
    }
}




