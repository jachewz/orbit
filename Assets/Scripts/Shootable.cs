using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public int FullHealth = 1;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = FullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
    }

}
