using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;
    public Transform chasePosition;
    public float chaseDeathOffset = 5f;
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
        if(transform.position.y < -32) {
            Die();
        }
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

        isGrounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, raycastLength, LayerMask.GetMask("Ground"));

        if (isGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))) { 
            rb.linearVelocity = new Vector2(rb.linearVelocityX, yVelocity);
        }
        isGrounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, raycastLength, LayerMask.GetMask("Ground"));
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
    }

    void Die() {
        Debug.Log("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
