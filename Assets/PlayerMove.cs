using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float h;
    public float speed;
    public GameObject model;
    Animator animator;
    Rigidbody2D rb;
    public int jumpforce;
    private void Awake()
    {
        animator = model.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("Dead", false);
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0, 0) * speed;
        animator.SetFloat("x", h);
        animator.SetBool("Attack", false);
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("Attack", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Dead", true);
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            animator.SetBool("Dead", false);
        }
    }
    private void FixedUpdate()
    {
        //rb.velocity += new Vector2(h, 0) * speed;
        if (rb.velocity.y == 0 && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpforce);
            animator.SetInteger("Jump", 10);
        }
        if (rb.velocity.y < -5)
        {
            animator.SetBool("Grounded", false);
            animator.SetInteger("Jump", 0);
        }
        if (rb.velocity.y == 0)
        {
            animator.SetBool("Grounded", true);
        }
    }

}
