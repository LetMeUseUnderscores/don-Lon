using System;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform playerPosition;
    public float distance = 1f;
    public float speedMultiplier = 1f;
    public float speed = 5f;
    public float bobSpeed = 10f;
    public float amplitude = 2f;
    public float yPosition = 5f;
    void Update()
    {
        float xMovement = speed * Time.deltaTime;
        if(playerPosition.position.x > transform.position.x + distance) {
            xMovement *= speedMultiplier;
        }   
        float yMovement = Mathf.Sin(Time.time * bobSpeed) * amplitude + yPosition - transform.position.y;
        transform.Translate(xMovement, yMovement, 0);    
    }
}
