using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Variables
    [SerializeField]
    float jumpVelocity = 10f;
    [SerializeField]
    float moveSpeed = 40f;
    float inputHorizontal;
    bool facingRight = true;
    bool isAlive = true;

    //References
    Rigidbody2D rigidbody2d;
    CapsuleCollider2D capsuleCollider2D;
    BoxCollider2D boxCollider2D;
    [SerializeField]
    LayerMask platformsLayerMask;
    Animator animator;

    void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        animator = transform.GetComponent<Animator>();
        capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        if (!isAlive)
            return;
            
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("takeOf");
            Jump();
        }

        if (IsGrounded() == true)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }

        Movement();

        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

        Die();
    }

    void Jump()
    {
        rigidbody2d.velocity = Vector2.up * jumpVelocity;
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            animator.SetBool("isRunning", true);

        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                animator.SetBool("isRunning", true);

            }
            else
            {
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                animator.SetBool("isRunning", false);
            }
        }
    }

    void Die()
    {
        if (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
            animator.SetTrigger("die");
        }
    }
}
