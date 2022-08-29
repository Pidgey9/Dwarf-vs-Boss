using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderUp : MonoBehaviour
{
    public float force;
    ConstantForce2D cf;
    private void Awake()
    {
        cf = GetComponent<ConstantForce2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            cf.force = Vector2.up * force;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cf.force = Vector2.zero;
    }
}
