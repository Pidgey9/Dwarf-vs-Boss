using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public Var bossLife;
    public Animator animator;
    private void Start()
    {
        bossLife.value = 10;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Axe"))
        {
            bossLife.value--;
            animator.SetTrigger("Take Damage");
            
        }
    }
    private void Update()
    {
        if (bossLife.value <= 0)
        {
            Destroy(gameObject);
        }
        if (bossLife.value < 5)
        {
            animator.SetTrigger("MidLife");
        }
    }
}
