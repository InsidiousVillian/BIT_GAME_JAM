using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D body;
    public float JumpForce = 10f; // Adjust jump force as needed

    bool grounded;
    public Vector2 boxSize;
    
    public float CastDistance;

    public LayerMask groundLayer;





    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump when pressing Escape
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, JumpForce); // Apply only jump force
        }
        else{
            Debug.Log("not working");
        }
    }

    void FixedUpdate()
    {
        // Move the player forward while preserving Y velocity
        body.velocity = new Vector2(speed, body.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.CompareTag("trigger"))
        {
            Debug.Log("Trigger has been triggered!");
        }
    }

    public bool isGrounded(){
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, CastDistance, groundLayer)){
            return true;
        }
        else{
            return false;
        }
    }
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position - transform.up *CastDistance, boxSize);
    }
}

