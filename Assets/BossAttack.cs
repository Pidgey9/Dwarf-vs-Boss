using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            rb.AddForce(new Vector2(-1000, 0));
            animator.SetTrigger("Dead");
        }
    }
}
