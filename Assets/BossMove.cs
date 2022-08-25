using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    float rand;
    float rand2;
    public float speed;
    private void Update()
    {
        rand = (Random.value - 0.5f);
        rand2 = (Random.value - 0.5f) * 0.1f;
        transform.position += new Vector3(rand * speed, rand, 0);
    }
}
