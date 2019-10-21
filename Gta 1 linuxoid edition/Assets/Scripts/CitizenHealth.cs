using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenHealth : MonoBehaviour
{
    public int Health, curHealth;
    public GameObject citizen;

    void Start()
    {
        Health = Random.Range(80, 100);
        curHealth = Health;
    }

    void Update()
    {
        if (curHealth <= 0)
        {
            //citizen = Instantiate(Resources.Load("coin", typeof(GameObject)), new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            //citizen.name = "Coins";
            citizen = Instantiate(Resources.Load("coin", typeof(GameObject)), new Vector2(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y), new Quaternion(0, 0, 0, 0)) as GameObject;
            citizen.name = "coin";
            //TODO
            //citizen = Instantiate(Resources.Load("Experience", typeof(GameObject)), new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            //citizen.name = "Experience";
            //citizen.GetComponent<SpawnCitizens>().amountOfCitizens -= 1;

            Destroy(gameObject);
        }
    }
}
