using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour

{
    public float maxVelocity = 20f;
    public float turnSpeed = 20f;
    public float speed = 2.0f;
    public float jumpSpeed = 20f;
    public bool isGrounded;
    Rigidbody rb;

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";

    Vector2 movementInput;
    public LayerMask mask;
    RaycastHit hit;
    bool jumpReset;
    public Transform mirror;
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
        mirror.position = transform.position;
        movementInput.Set(Input.GetAxis(horizontalCtrl), 0);

        isGrounded = Physics.SphereCast(transform.position, 0.45f, Vector3.down, out hit, 0.1f, mask);

        if (Input.GetAxis(jumpButton) > 0.75f)
        {
            jumpReset = true;
        }

        if (Input.GetAxis(jumpButton) != 0 && isGrounded && jumpReset)
        {
            Jump();
            jumpReset = false;
        }






        //sound - int i = Random.Range(0,jumpClips.Length);
        //AudioSource.PlayClipAtPoint((whateveraudiois),transform.position);
    }

    private void FixedUpdate()
    {
        Vector3 projectedMovement = Vector3.ProjectOnPlane(new Vector3(movementInput.x, 0, 0), hit.normal);
        rb.AddForce(new Vector3(movementInput.x, movementInput.y, 0f) * speed);
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        isGrounded = false;
    }
}




