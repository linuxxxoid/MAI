using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizensControl : MonoBehaviour
{
    public GameObject[] myNodes;
    public float currentSpeed = 1.3f;
    private float partRunSpeed = 0.3f;
    private int currentNode = 0;

    public GameObject Citizen;
    public float maxSpeed = 1.9000009f;
    private bool isFaceRight = true;

    private Rigidbody2D rb_citizens;
    private Animator anim_citizens;

    private void Start()
    {
        rb_citizens = GetComponent<Rigidbody2D>();
        anim_citizens = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = transform.position.x;
        float moveY = transform.position.y;
        Movement();
        Behaviour();

        if (Mathf.Abs(transform.position.x - moveX) > Mathf.Abs(transform.position.y - moveY)) {
            moveX = transform.position.x - moveX;
            moveY = 0f;
        }
        else
        {
            moveY = transform.position.y - moveY;
            moveX = 0f;
        }


        anim_citizens.SetFloat("Speed", moveY);
        anim_citizens.SetFloat("Rotation", Mathf.Abs(moveX));


        if (moveX > 0 && !isFaceRight)
            Flip();
        else if (moveX < 0 && isFaceRight)
            Flip();
    }


    private void Flip()
    {
        isFaceRight = !isFaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
        }
    }

    private void Movement()
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

    private void Behaviour()
    {
        // citizen starts running if user is shooting
        GameObject gamer = GameObject.FindWithTag("Player");
        if (gamer.transform.GetChild(2).GetComponent<CircleCollider2D>().enabled == true
        &&
        Vector3.Distance(gamer.transform.position, transform.position) <= 10f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z), (currentSpeed + 10f + partRunSpeed) * Time.deltaTime);
        }

    }

}


