using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    //Variables
    [SerializeField]
    float enemyMoveSpeed = 1f;
    float inputHorizontal;
    bool facingLeft = true;
    
    //References
    Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
    }   

    void Update()
    {
        rigidBody2D.velocity = new Vector2(-enemyMoveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        enemyMoveSpeed = -enemyMoveSpeed;
        FlipEnemy();
    }

    void FlipEnemy()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }
}
