using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public SpriteRenderer flame;

    public Rigidbody2D rb;

    private Vector3 velocity = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        flame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(
            Input.GetAxis("Horizontal") * Speed,
            Input.GetAxis("Vertical") * Speed,
            0);

        



        if (velocity.x!=0 || velocity.y!=0)
        {
            flame.enabled = true;
        }
        else
        {
            flame.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        //transform.position += velocity * Time.deltaTime;
        rb.AddForce(velocity * Time.deltaTime);
    }
}
