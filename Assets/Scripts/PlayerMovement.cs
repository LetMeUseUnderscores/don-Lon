using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D playerCollider;
    public float xVelocity = 6f;
    public float yVelocity = 6f;
    public float raycastLength = 0.81f;
    public bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        if(transform.position.y < -32) {
            this.Die();
        }
        float moveInput = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.identity;
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            this.Die();
        }
    }

    void Die() {
        Debug.Log("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
