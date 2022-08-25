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
    public GameObject axeColliderH;
    public GameObject axeColliderR;
    public GameObject axeColliderL;

    private void Awake()
    {
        animator = model.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0, 0) * speed;
        animator.SetFloat("x", Mathf.Abs(h));
        animator.SetBool("Attack", false);
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("Attack");
            axeColliderH.SetActive(true);
            axeColliderR.SetActive(true);
            axeColliderL.SetActive(true);
        }
        else if (rb.velocity.y == 0)
        {
            axeColliderH.SetActive(false);
            axeColliderR.SetActive(false);
            axeColliderL.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("Dead");
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            animator.SetTrigger("Resurrect");
        }
    }
    private void FixedUpdate()
    {
        //rb.velocity += new Vector2(h, 0) * speed;
        if (rb.velocity.y == 0 && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpforce);
            animator.SetTrigger("Jump");
        }
        if (rb.velocity.y < -5)
        {
            animator.SetBool("Grounded", false);
        }
        if (rb.velocity.y == 0)
        {
            animator.SetBool("Grounded", true);
        }
        if ((rb.velocity.y < -15 && rb.velocity.y > -16) || rb.velocity.y < -100)
        {
            animator.SetTrigger("Dead");
        }
    }

}
