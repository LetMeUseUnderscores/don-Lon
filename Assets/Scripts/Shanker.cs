using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shanker : MonoBehaviour
{
    public Animator animator;
    public Transform playerPosition;
    public AudioSource scream;
    public Collider2D playerCollider;
    public float moveSpeed = 1f;
    public float shankSpeed = 4f;
    public float attackChance = 0.01f;
    public float attackDistance = 5f;
    public float movementStartDistance = 20f;
    public bool attackOnSight = false;
    public bool isEnemy = false;    
    void Start() {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, true);
        animator.SetBool("isHostile", false);
        animator.SetBool("isDead", false);
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
            if(playerPosition.position.x > transform.position.x && isEnemy) {
                transform.localScale = new Vector3(0.8f, 0.8f, 1);
            } else {    
                transform.localScale = new Vector3(-0.8f, 0.8f, 1);
            }
            transform.Translate(moveSpeed * Time.deltaTime * Vector2.left);
            if(attackOnSight || (!isEnemy && transform.position.x < playerPosition.position.x - attackDistance))
            {
                if(UnityEngine.Random.value < attackChance)
                {
                    attackOnSight = false;
                    isEnemy = true;
                    scream.Play();
                    animator.SetBool("isHostile", true);
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
                ShankerDeath(); 
                enabled = false; 
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (enabled && collision.gameObject.CompareTag("Death")) {
            if(collision.gameObject.transform.localScale.x < 0) {
                if(collision.gameObject.transform.position.x > transform.position.x) {
                    ShankerDeath();
                }
            } else {
                if(collision.gameObject.transform.position.x < transform.position.x) {
                    ShankerDeath();
                }
            }
        }
    }
    
    void ShankerDeath() {
        animator.SetBool("isDead", true);
        animator.enabled = false;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
        transform.gameObject.layer = 3;
        transform.gameObject.tag = "Ground";
        isEnemy = false;
        enabled = false;  
    }
}
