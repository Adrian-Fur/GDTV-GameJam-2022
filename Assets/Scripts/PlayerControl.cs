using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float jumpVelocity = 10f;
    [SerializeField]
    float moveSpeed = 40f;

    Rigidbody2D rigidbody2d;
    BoxCollider2D boxCollider2D;
    [SerializeField]
    LayerMask platformsLayerMask;
    Animator animator;

    void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        animator = transform.GetComponent<Animator>();
    }
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {   
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        Movement();
        // Flip();
    }

    void Flip()
    {
       
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
        } 
        else 
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }

        //animator.SetBool("isRunning", true);
        
    }
}
