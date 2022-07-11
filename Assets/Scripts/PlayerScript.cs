using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    // SerializeField variables
    [SerializeField] int speedX = 10;
    [SerializeField] int jumpForce = 10;
    [SerializeField] int maxJumps = 2;

    // Public variables
    public Rigidbody2D rb;
    public bool isTouchingGround = true;
    public bool hasDoubleJumped = false;
    public Vector3 Movement;

    // Private variables
    private int jumps = 0;

    // Update is called once per frame
    void Update() {
        // Left-Right movement
        float InputX = Input.GetAxis("Horizontal");
        Movement = new Vector3(InputX * speedX, 0, 0);

        // Enter Jump method
        if (Input.GetKeyDown(KeyCode.Space)||(Input.GetKeyDown(KeyCode.W))||(Input.GetKeyDown(KeyCode.UpArrow))) {
            Jump();
        }
        Movement = Movement * Time.deltaTime;
        transform.Translate(Movement);
        }

    // Player can jump for "maxJumps" times allowed
    void Jump() {
        if (jumps > 0) { //Check if player has jumped for the maximum times, then jumps. Otherwise, falls and resets boolean
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isTouchingGround = true;
            jumps--;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            // Reset "Jump" related booleans
            isTouchingGround = true;
            jumps = maxJumps;
        }
    }       
}