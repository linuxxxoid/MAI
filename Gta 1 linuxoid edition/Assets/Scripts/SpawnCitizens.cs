using UnityEngine;
using System.Collections;

public class SpawnCitizens : MonoBehaviour
{
    public GameObject[] citizens;
    public int amountOfCitizens = 0;
    private int maxAmountOfCitizens = 50;
    private float[] positions = { -5.33f, 5.53f };
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (amountOfCitizens < maxAmountOfCitizens)
        {
            int rnd = Random.Range(0, 100);
            if (rnd % 2 == 0)
            {
                Instantiate(
                    citizens[Random.Range(0, citizens.Length)],
                    new Vector3(positions[Random.Range(0, positions.Length - 1)], 7, 0),
                    Quaternion.Euler(new Vector3(0, 0, 0))
                );
                amountOfCitizens++;
            }
            else
            {
                Instantiate(
                    citizens[Random.Range(0, citizens.Length)],
                    new Vector3(positions[Random.Range(0, positions.Length - 1)], -7, 0),
                    Quaternion.Euler(new Vector3(0, 0, 0))
                );
                amountOfCitizens++;
            }
            yield return new WaitForSeconds(3f);

        }
    }

}
