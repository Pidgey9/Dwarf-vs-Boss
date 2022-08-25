using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    float rand;
    float rand2;
    public float speed;
    public float direction;
    private void Awake()
    {
        direction = 0.6f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CageL"))
        {
            direction = 0.4f;
        }
        if (collision.CompareTag("CageR"))
        {
            direction = 0.6f;
        }
    }
    private void Update()
    {
        rand = (Random.value - direction);
        rand2 = Random.value * 0.1f;
        transform.position += new Vector3(rand * speed, rand2, 0);
    }
}
