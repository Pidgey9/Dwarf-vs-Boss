using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public Var bossLife;
    public Animator animator;
    public GameObject mobilePlatform;
    public GameObject spawnFlame;
    private void Start()
    {
        bossLife.value = 10;
    }
    private void Update()
    {
        if (bossLife.value <= 0)
        {
            mobilePlatform.SetActive(true);
            Destroy(gameObject);
        }
        if (bossLife.value < 5)
        {
            animator.SetTrigger("MidLife");
            spawnFlame.SetActive(true);
        }
    }
}
