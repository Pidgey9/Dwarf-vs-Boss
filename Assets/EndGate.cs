using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour
{
    public GameObject startGate;
    public GameObject endGate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            startGate.SetActive(false);
            endGate.SetActive(true);
        }
        if (collision.CompareTag("Beer"))
        {
            
        }
    }
}
