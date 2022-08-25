using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameGenerator : MonoBehaviour
{
    public GameObject Flame;
    int count;
    private void Awake()
    {
        count = 0;
    }
    private void Update()
    {
        if (count % 1000 == 0)
        {
            Vector2 spawn = transform.position;
            spawn.y = Random.value * 3;
            Instantiate(Flame, spawn, Quaternion.identity);
        }
        count++;
    }
}
