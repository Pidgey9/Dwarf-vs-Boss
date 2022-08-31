using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameGenerator : MonoBehaviour
{
    public GameObject Flame;
    public int count;
    private void Update()
    {
        if (count % 1000 == 0)
        {
            Vector3 spawn = transform.position;
            spawn.y += Random.value * 10;
            Instantiate(Flame, spawn, Quaternion.identity);
        }
        count++;
    }
}
