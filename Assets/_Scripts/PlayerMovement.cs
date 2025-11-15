using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float deltaSpeed = 3f;
    public float jumpForce = 12.0f;
    public float enemyBumpForce = 3.0f;
    public BoxCollider2D groundCollider;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;
    private Animator animator;
    private bool idle, walking, jumping;
    private SpriteRenderer sr;

    // Improvements to consider:
    // - Double jump
    // - Easing into movement (accelerating more slowly)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;

        animator = GetComponent<Animator>();

        idle = false;
        walking = false;

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._gameOver) return;

        Vector3 vel = rb.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            //makes turning feel better
            if(vel.x > 0)
            {
                vel.x = 0;
            }

            vel.x -= deltaSpeed * Time.deltaTime;
            if (vel.x <= -speed)
            {
                vel.x = -speed;
            }

            if (!walking)
            {
                walking = true;
                animator.Play("Walk");
            }
            idle = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            //makes turning feel better
            if (vel.x < 0)
            {
                vel.x = 0;
            }

            vel.x += deltaSpeed * Time.deltaTime;
            if (vel.x >= speed)
            {
                vel.x = speed;
            }

            if (!walking)
            {
                walking = true;
                animator.Play("Walk");
            }
            idle = false;
        }
        else
        {
            vel.x = 0;
            walking = false;
            if (!idle)
            {
                animator.Play("Idle");
                idle = true;
            }
        }

        rb.velocity = vel;


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            animator.Play("Jump");
            jumping = true;
        }

        if (IsGrounded() && !idle)
        {
            jumping = false;
            idle = true;
        }
        if (vel.x == 0)
        {
            idle = true;
            walking = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") && jumping)
        {
            jumping = false;
            animator.Play("Idle");
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            Vector2 myCenter = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            myCenter.y = contactPoint.y;
            Vector2 forceVector = myCenter - contactPoint;
            forceVector.y += 1;

            rb.AddForce(forceVector * enemyBumpForce, ForceMode2D.Impulse);

            GameManager.SubtractLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            GameManager.score += 100;

            Destroy(collision.gameObject);
        }
    }

    private bool IsGrounded()
    {
         return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
