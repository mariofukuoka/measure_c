using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementState
    {
        Idle = 0,
        Running = 1,
        Jumping = 2,
        Falling = 3
    }

    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private int JumpForce = 14;
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private static readonly int AnimState = Animator.StringToHash("AnimationState");
    private MovementState currentMovementState = MovementState.Idle;

    [SerializeField] private AudioSource jumpSoundEffect;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isOnGround())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        currentMovementState = MovementState.Idle;

        if (dirX > 0f)
        {
            currentMovementState = MovementState.Running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            currentMovementState = MovementState.Running;
            spriteRenderer.flipX = true;
        }
        
        if (rb.velocity.y > .1f)
        {
            currentMovementState = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            currentMovementState = MovementState.Falling;
        }

        animator.SetInteger(AnimState, (int)currentMovementState);
    }

    private bool isOnGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size,
            0f, Vector2.down, .1f, groundMask);
    }
}
