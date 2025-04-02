using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D body;
   
    void Start()
    {
        //allows us to control physics of gameobject - in fixed update we will use this to move player
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.linearVelocity = new Vector2(speed, body.linearVelocity.x);
    }

    void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Collided with: " + other.name); // This checks if anything is detected

    if (other.CompareTag("trigger"))
    {
        Debug.Log("Trigger has been triggered!");
    }
}
}
