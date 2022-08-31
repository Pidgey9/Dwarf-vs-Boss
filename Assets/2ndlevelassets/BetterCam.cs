using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterCam : MonoBehaviour
{
    public Transform player;
    public float smoothValue;
    public float yOffSet;
    float xVelocity;
    float yVelocity;
    private void LateUpdate()
    {
        float newX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref xVelocity, smoothValue);
        float newY = Mathf.SmoothDamp(transform.position.y, player.position.y, ref yVelocity, smoothValue);
        transform.position = new Vector3 (newX, newY + yOffSet, -10);
    }
}
