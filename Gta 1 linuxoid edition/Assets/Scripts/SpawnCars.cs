using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour
{
    public GameObject[] cars;
    public int amountOfCars = 0;
    private int maxAmountOfCars = 30;
    private float[] positions = { -2.83f, -0.8f, 1.21f, 3.14f};
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        while(amountOfCars < maxAmountOfCars)
        {
            int rnd = Random.Range(0, 100);
            if (rnd % 2 == 0) {
                Instantiate(
                    cars[Random.Range(0, cars.Length)],
                    new Vector3(positions[Random.Range(0, 2)], 7, 0),
                    Quaternion.Euler(new Vector3(0, 0, 180))
                );
            }
            else {
                Instantiate(
                    cars[Random.Range(0, cars.Length)],
                    new Vector3(positions[Random.Range(2, positions.Length)], -7, 0),
                    Quaternion.Euler(new Vector3(0, 0, 0))
                );
            }
            yield return new WaitForSeconds(3f);

        }
    }

}
