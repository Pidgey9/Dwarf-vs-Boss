using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTwoMove : MonoBehaviour
{
    float h;
    Rigidbody2D rb;
    public Animator animator;
    public float tspeed;
    public float rspeed;
    public float jump;
    public Var jumpCount;
    ConstantForce2D cf;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cf = GetComponent<ConstantForce2D>();
    }
    private void Start()
    {
        jumpCount.value = 0;
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        animator.SetFloat("x", h);
        transform.position += Vector3.right * h * tspeed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (h != 0)
        {
            rb.AddForce(Vector2.right * h * rspeed * Time.fixedDeltaTime);
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("Grounded", false);
            rb.gravityScale = 2;
        }
        else rb.gravityScale = 1;
        if (jumpCount.value > 0)
        {
            cf.force = Vector2.zero;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            animator.SetBool("Grounded", true);
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)) && jumpCount.value == 0)
            {
                //rb.AddForce(Vector2.up * jump);
                cf.force = Vector2.up * jump;
                jumpCount.value++;
                animator.SetTrigger("Jump");
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
