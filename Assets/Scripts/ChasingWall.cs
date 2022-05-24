using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingWall : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minSpeed = 5f;
    [SerializeField] float maxSpeed = 20f;
    float maxDistance = 100f;
    float minDistance = 20f;
    Rigidbody2D rigidBody2D;
    Transform target;
    Vector2 moveDirection;

    void Awake() 
    {
       rigidBody2D = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > maxDistance)
        {
            moveSpeed = maxSpeed;
        }
        else if (distance < minDistance)
        {   
            moveSpeed = minSpeed;
        }
        else
        {
            var distRatio = (distance - minDistance) / (maxDistance - minDistance);
            var diffSpeed = maxSpeed - minSpeed;
            moveSpeed = (distRatio * diffSpeed) +  minSpeed;
        }

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    void FixedUpdate() 
    {
        rigidBody2D.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }
}
