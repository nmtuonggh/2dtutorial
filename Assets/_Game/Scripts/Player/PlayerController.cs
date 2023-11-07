using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float horizontalInput;
    [SerializeField] protected LayerMask jumpAbleGround;
    [SerializeField] protected AudioSource jumpSound;
    [SerializeField] protected AudioSource runSound;


    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    protected BoxCollider2D collider;


    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        JumpAndMovement();
        //Xử lý xoay người
        UpdateAnimation();
    }

    private void JumpAndMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isOnGround())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (horizontalInput > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    protected bool isOnGround()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size,
            0f, Vector2.down, 0.1f, jumpAbleGround);
    }
}