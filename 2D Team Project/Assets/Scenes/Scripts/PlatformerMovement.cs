using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    bool grounded = false;
    //where
    AudioSource audioSource;
    //what sound do we want to play
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //when we press left or right, move the char left/right
        float moveX = Input.GetAxis("Horizontal");
        //maintain the integrity of our Y velocity
        Vector3 velocity= rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        // if you press the space key AND you're on the ground, jump the char
        if (Input.GetButtonDown("Jump")  && grounded)
        {
            if(audioSource != null && jumpSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(jumpSound);
            }
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            grounded= true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
