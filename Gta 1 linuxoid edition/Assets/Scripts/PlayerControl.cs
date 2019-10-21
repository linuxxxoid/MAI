using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject User;
    public float maxSpeed = 2f;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    private Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", moveY);
        anim.SetFloat("Rotation", Mathf.Abs(moveX));


        //rb.velocity = new Vector2(moveY * maxSpeed, rb.velocity.y);
        // rb.MovePosition(rb.position + Vector2.up * moveY * maxSpeed * Time.deltaTime);
        //rb.MovePosition(rb.position + Vector2.right * moveX * maxSpeed * Time.deltaTime);
        Vector3 dir = new Vector3(moveX, moveY, 0);
        transform.Translate(dir.normalized * Time.deltaTime * maxSpeed);
        if (moveX > 0 && !isFacingRight)
            Flip();
        else if (moveX < 0 && isFacingRight)
            Flip();
    }


    private void Flip() {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x* -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car")) {
            Destroy(gameObject);
        }
    }

}
