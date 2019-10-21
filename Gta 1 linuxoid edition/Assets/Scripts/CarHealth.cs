using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public int Health, curHealth;
    public GameObject car;

    void Start()
    {
        Health = Random.Range(300, 410);
        curHealth = Health;
    }

    void Update()
    {
        if (curHealth <= 0)
        {

            car = Instantiate(Resources.Load("coin", typeof(GameObject)), new Vector2(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y), new Quaternion(0, 0, 0, 0)) as GameObject;
            car.name = "coin";
            //TODO
            //car = Instantiate(Resources.Load("Experience", typeof(GameObject)), new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            //car.name = "Experience";
            //maybe it's worth to do reputation.
            car.GetComponent<SpawnCars>().amountOfCars -= 1;

            Destroy(gameObject);
        }
    }
}
