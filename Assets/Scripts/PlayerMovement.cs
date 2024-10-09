using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;
    public float xVelocity = 5f;
    public float yVelocity = 5f;
    public float raycastLength = 0.5f;
    public bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
        rb.linearVelocity = new Vector2(moveInput * xVelocity, rb.linearVelocityY);

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))) { 
            rb.linearVelocity = new Vector2(rb.linearVelocityX, yVelocity);
        }
        isGrounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, raycastLength, LayerMask.GetMask("Ground"));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}
