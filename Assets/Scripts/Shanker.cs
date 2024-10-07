using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shanker : MonoBehaviour
{
    public Transform playerPosition;
    public Collider2D playerCollider;
    public float moveSpeed = 1f;
    public float shankSpeed = 4f;
    public float attackChance = 0.01f;
    public float attackDistance = 5f;
    public float movementStartDistance = 20f;
    public bool isEnemy = false;    
    void Start() {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, true);
    }
    bool beginMovement = false;
    void Update()
    {
        if(!beginMovement && Math.Abs(transform.position.x - playerPosition.position.x + 1) < movementStartDistance)
        {
            beginMovement = true;
        }
        if(beginMovement)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.left);
            if(!isEnemy && transform.position.x < playerPosition.position.x - attackDistance)
            {
                if(UnityEngine.Random.value < attackChance)
                {
                    isEnemy = true;
                }
            }

            if(isEnemy)
            {
                transform.Translate(shankSpeed * Time.deltaTime * ((playerPosition.position.x > transform.position.x) ? Vector2.right : Vector2.left));
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
                transform.gameObject.tag = "Death";
            } else {
                transform.gameObject.tag = "Untagged";
            }
            if(Math.Abs(transform.rotation.z) > 0.2)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
                transform.gameObject.layer = 3;
                transform.gameObject.tag = "Ground";
                isEnemy = false;
                enabled = false;    
            }
        }
    }
}
