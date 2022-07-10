using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int speedX = 10;
    [SerializeField] int jumpForce = 10;

    public Rigidbody2D rb;

    private bool isTouchingGround = false;
    private bool hasDoubleJumped = false;

    // Update is called once per frame
    void Update(){
        // Left-Right movement
        float InputX = Input.GetAxis("Horizontal");

        Vector3 Movement = new Vector3(InputX * speedX, 0, 0);

        // Double Jump 
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if ((!isTouchingGround)&&(!hasDoubleJumped)){
                if (Input.GetKeyDown(KeyCode.Space)){
                    Movement.y = 0;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    hasDoubleJumped = true;
                }
            }
        }
        Movement = Movement * Time.deltaTime;
        transform.Translate(Movement);   
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            // Reset "Jump" booleans
            isTouchingGround = true;
            hasDoubleJumped = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isTouchingGround = false;
            hasDoubleJumped = false;
        }   
    }
}