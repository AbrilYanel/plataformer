using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public float jumpInterval = 2f;
    public float minX = -27f;
    public float maxX = -2f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded = false;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Jump", jumpInterval, jumpInterval);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
       
        float horizontalMovement = moveSpeed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(Vector3.right * horizontalMovement);
            if (transform.position.x >= maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * horizontalMovement);
            if (transform.position.x <= minX)
            {
                movingRight = true;
            }
        }

       
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f, groundMask);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); 
        }
    }
}
