using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float thrust = 10f;
    public float AngularSpeed = 20f;
    public SpriteRenderer flame;

    public Rigidbody2D rb;
    private bool boost = false;
    private float rotate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        flame.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        //Accelerate
        if (Input.GetButton("Jump") || Input.GetAxis("Vertical")>0) 
        {
            boost = true;
            flame.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            boost = false;
            flame.enabled = false;
        }

        rotate = Input.GetAxis("Horizontal");


    }

    private void FixedUpdate()
    {
        if (boost)
        {
            rb.AddForce(thrust * transform.up );
        }

        rb.transform.Rotate(0, 0, -rotate * AngularSpeed );
    }
}
