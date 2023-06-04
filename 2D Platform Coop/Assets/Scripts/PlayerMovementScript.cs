using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement Settings")]
    Rigidbody2D rb;
    [SerializeField] float jumpForce;
    [SerializeField] float movementSpeed;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform playerBody;

    [Header("Keyboard Controls")]
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode jump = KeyCode.Space;

    [Header("SFX")]
    [SerializeField] PlayerSfx playerSfx;

    void Start()
    {
        playerSfx = GetComponent<PlayerSfx>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerJump();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            playerBody.transform.rotation = Quaternion.identity;
        }
        else if (Input.GetKey(left))
        {   
            rb.velocity = new Vector2 (-movementSpeed, rb.velocity.y);
            playerBody.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(jump))
            {
                playerSfx.PlayJumpSound(0.6f);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PowerUps")
        {
            playerSfx.PlayPickUpSound(1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    //things to do
    // player move jump shoot
    //character should have a face direction 
    // shoot direction they are facing
    // implement health
    // UI for the health
    // menu start
    // game over
    // 
}
