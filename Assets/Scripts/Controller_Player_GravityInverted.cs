using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_GravityInverted : Controller_Player
{
    private bool isGravityInverted = false;

    public override void FixedUpdate()
    {
        if (GameManager.actualPlayer == playerNumber)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                InvertGravity();
            }

            base.FixedUpdate();
        }
    }

    public override bool IsOnSomething()
    {
        Vector3 direction = isGravityInverted ? Vector3.up : Vector3.down;
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), direction, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Vector3 jumpDirection = isGravityInverted ? Vector3.down : Vector3.up;
                rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void InvertGravity()
    {
        isGravityInverted = !isGravityInverted;
        Physics.gravity = new Vector3(Physics.gravity.x, -Physics.gravity.y, Physics.gravity.z);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
    }
}
