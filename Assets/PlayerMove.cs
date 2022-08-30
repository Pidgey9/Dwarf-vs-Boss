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
    public GameObject mobilePlatform;

    private void Awake()
    {
        animator = model.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0, 0) * speed * Time.deltaTime;
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
        /*if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("Dead");
        }*/
        if (Input.GetKey(KeyCode.Backspace))
        {
            animator.SetTrigger("Resurrect");
        }
    }
    private void FixedUpdate()
    {
        if ((rb.velocity.y == 0 && Input.GetKey(KeyCode.Space)) || (rb.velocity.y == 0 && Input.GetKey(KeyCode.S)))
        {
            rb.AddForce(Vector2.up * jumpforce * Time.fixedDeltaTime);
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
        if (rb.velocity.y < -100)
        {
            animator.SetTrigger("Dead");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mobile"))
        {
            transform.SetParent(mobilePlatform.transform);
        }
        else
        {
            transform.SetParent(null);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mobile"))
        {
            transform.SetParent(null);
        }
    }

}
