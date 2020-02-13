using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float MassG = 10f;
    private static GameObject[] attractedObjects;

    private void FixedUpdate()
    {
        attractedObjects = GameObject.FindGameObjectsWithTag("Movable");
        foreach(GameObject attractedObject in attractedObjects)
        {
            Attract(attractedObject.GetComponent<Rigidbody2D>());
        }
        attractedObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject attractedObject in attractedObjects)
        {
            Attract(attractedObject.GetComponent<Rigidbody2D>());
        }
    }
    void Attract(Rigidbody2D rbToAttract)
    {
        Vector2 position = transform.position;
        Vector2 direction = position - rbToAttract.position;
        float distance = direction.magnitude;

        if(distance == 0)
        {
            return;
        }

        float forceMagnitude = rbToAttract.mass * MassG / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
