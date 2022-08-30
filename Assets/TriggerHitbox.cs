using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHitbox : MonoBehaviour
{
    public Var bossLife;
    public Animator bossShine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hitbox"))
        {
            bossLife.value--;
            bossShine.SetTrigger("Take Damage");
        }
    }
}
