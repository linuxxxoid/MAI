using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public GameObject[] myNodes;
    public float currentSpeed = 3f;
    private int currentNode = 0;

    void Update()
    {
        Drive();
    }

    private void Drive()
    {
        if (myNodes.Length != 0)
        {
            if (Vector3.Distance(myNodes[currentNode].transform.position, transform.position) <= 0)
            {
                currentNode++;
            }
            if (currentNode >= myNodes.Length)
            {
                currentNode = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, myNodes[currentNode].transform.position, currentSpeed * Time.deltaTime);
        }
    }

}
