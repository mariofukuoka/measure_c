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
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private static readonly int AnimState = Animator.StringToHash("AnimationState");
    private MovementState currentMovementState = MovementState.Idle;
    private bool isJumping;

    public PlayerMovement()
    {
        isJumping = true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
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
}
