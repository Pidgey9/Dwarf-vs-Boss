using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public Var bossLife;
    private void Start()
    {
        bossLife.value = 10;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Axe"))
        {
            bossLife.value--;
        }
    }
    private void Update()
    {
        if (bossLife.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
