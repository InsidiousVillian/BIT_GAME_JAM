using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private TrailRenderer _trailRenderer;

  
    public float speed = 5f;
    public Rigidbody2D body;
    public float JumpForce = 10f; // Adjust jump force as needed

    bool grounded;
    public Vector2 boxSize;
    
    public float CastDistance;

    public LayerMask groundLayer;

    public GameObject RunningSection;
    public float sectionLength = 10f;

    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 dashingDir; 
    private bool _isDashing;
    private bool _canDash;




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
            SpawnNextSection();
        }

    }

     void SpawnNextSection()
    {
        // Get the Y position of the current running section
        float yPosition = RunningSection.transform.position.y; 

        // Spawn the new section at the same Y position
        Vector2 spawnPosition = new Vector2(transform.position.x + sectionLength, yPosition);

        // Instantiate the new section
        GameObject newSection = Instantiate(RunningSection, spawnPosition, Quaternion.identity);

        // Destroy the previous section after 4 seconds
        Destroy(RunningSection, 4f);

        // Update RunningSection to reference the new section
        RunningSection = newSection;

        Debug.Log("New Section Spawned at: " + spawnPosition); // Debugging
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

