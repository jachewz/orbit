using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Rigidbody2D rb;
    //public float Speed = 5f;
    public int Damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit" + collision.collider.name);
        Shootable shootable = collision.collider.gameObject.GetComponent<Shootable>();
        if (shootable)
        {   
            shootable.Damage(Damage);
        }
        gameObject.SetActive(false);
        
    }
}
