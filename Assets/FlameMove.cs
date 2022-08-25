using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMove : MonoBehaviour
{
    public float speed;
    int count;
    private void Update()
    {
        transform.position += Vector3.left * speed;
        if (count > 10000)
        {
            Destroy(gameObject);
        }
        count++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
