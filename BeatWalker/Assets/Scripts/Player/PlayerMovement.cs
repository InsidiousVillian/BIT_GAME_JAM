using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D body;
    public float JumpForce = 10f; // Adjust jump force as needed

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump when pressing Escape
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, JumpForce); // Apply only jump force
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
}

