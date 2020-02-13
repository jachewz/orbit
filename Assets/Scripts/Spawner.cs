using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Player;
    public GameObject[] Planets;
    public GameObject Asteroid;

    public int NumberOfPlanets = 100;
    public float PlanetSpread = 30f;
    public float MinPlanetScale = 1f;
    public float MaxPlanetScale = 3f;

    public int NumberOfAsteroids = 3;
    public float MinAsteroidSpread = 5f;
    public float MaxAsteroidSpread = 10f;
    public float AsteroidForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 1f, 3f);
    }

    private void Awake()
    {
        for (int i = 0; i < NumberOfPlanets; i++)
        {
            SpawnPlanet();
        }
    }

    public void SpawnPlanet()
    {

        Vector3 randPosition = new Vector3(
            Random.Range(-PlanetSpread, PlanetSpread), 
            Random.Range(-PlanetSpread, PlanetSpread), 
            0);
        float planetScale = Random.Range(MinPlanetScale, MaxPlanetScale);

        Collider2D[] collidersOverlapped = new Collider2D[1];
        int numberOfCollidersFound = Physics2D.OverlapCircleNonAlloc(randPosition, planetScale, collidersOverlapped);
        if (numberOfCollidersFound!=0)
        {
            SpawnPlanet();
            return;
        }

        int randomIndex = Random.Range(0, Planets.Length);
        GameObject clone = Instantiate(Planets[randomIndex], Player.position + randPosition, Random.rotation);

        clone.transform.localScale = new Vector3(planetScale, planetScale, planetScale);

        //clone.GetComponent <MeshRenderer> ().material.mainTextureOffset = new Vector2(Random.value, Random.value);

    }

    public void SpawnAsteroid()
    {
        float randXPosition = Random.Range(-MaxAsteroidSpread, MaxAsteroidSpread);
        while (Mathf.Abs(randXPosition) < MinAsteroidSpread)
        {
            randXPosition = Random.Range(-MaxAsteroidSpread, MaxAsteroidSpread);
        }

        float randYPosition = Random.Range(-MaxAsteroidSpread, MaxAsteroidSpread);
        while (Mathf.Abs(randYPosition) < MinAsteroidSpread)
        {
            randYPosition = Random.Range(-MaxAsteroidSpread, MaxAsteroidSpread);
        }

        Vector3 randPosition = new Vector3(
            randXPosition,
            randYPosition,
            0);

        Collider2D[] collidersOverlapped = new Collider2D[1];
        int numberOfCollidersFound = Physics2D.OverlapCircleNonAlloc(randPosition, 1, collidersOverlapped);
        if (numberOfCollidersFound != 0)
        {
            SpawnAsteroid();
            return;
        }

        GameObject clone = Instantiate(Asteroid, Player.position + randPosition, Random.rotation);

        Rigidbody2D cloneRb = clone.GetComponentInChildren<Rigidbody2D>();

        if (cloneRb)
        {
            cloneRb.AddForce(Random.insideUnitCircle * AsteroidForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //SpawnPlanet();
            SpawnAsteroid();
        }
    }
}
