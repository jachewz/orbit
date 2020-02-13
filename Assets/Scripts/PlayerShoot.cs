using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody2D Bullet;
    public GameObject Player;
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(Bullet, transform.position, transform.rotation);
            bulletClone.gameObject.GetComponent<Bullet>().enabled = true;
            bulletClone.gameObject.SetActive(true);
            bulletClone.velocity = transform.up * Speed;
        }
    }
}
