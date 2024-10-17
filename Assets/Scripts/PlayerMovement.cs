using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Collider2D playerCollider;
    public Transform chasePosition;
    public float chaseDeathOffset = 5f;
    public float xVelocity = 6f;
    public float yVelocity = 6f;
    public float raycastLength = 0.85f;
    public bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        if(transform.position.y < -8) {
            Die();  
        }
        float moveInput = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) 
            || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            animator.SetBool("isRunning", true);    
        } else{
            animator.SetBool("isRunning", false);
        }
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1); // Facing right
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 1); // Facing left
        }
        rb.linearVelocity = new Vector2(moveInput * xVelocity, rb.linearVelocityY);

        isGrounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, raycastLength, LayerMask.GetMask("Ground"));

        if (isGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))) { 
            rb.linearVelocity = new Vector2(rb.linearVelocityX, yVelocity);
        }
        if(chasePosition.position.x + chaseDeathOffset >= transform.position.x) {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        } 
        else if (collision.gameObject.CompareTag("ChangeLevel"))
        {
            LoadNextLevel();
        }
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index exceeds the number of scenes in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load, loading first level.");
            SceneManager.LoadScene(0); // Loop back to the first scene
        }
    }
    void Die() {
        Debug.Log("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
