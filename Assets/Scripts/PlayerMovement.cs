using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movement_scalar;
    public float max_speed;
    private Rigidbody2D rb;

    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        float x_movement = Input.GetAxis("Horizontal");

        if(rb.velocity.magnitude < max_speed)
        {
            Vector2 movement = new Vector2(x_movement, 0);
            rb.AddForce(movement_scalar * movement);
        }




    }
}
