using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_GravityInverted : Controller_Player
{
    private bool gravityInverted = false;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetKeyDown(KeyCode.G) && GameManager.actualPlayer == playerNumber)
        {
            InvertGravity();
        }

        if (gravityInverted)
        {
            base.rb.AddForce(new Vector3(0, 30f, 0));
        }
    }

    private void InvertGravity()
    {
        gravityInverted = !gravityInverted;
        Physics.gravity = gravityInverted ? new Vector3(0, 30, 0) : new Vector3(0, -30, 0);
        jumpForce = gravityInverted ? -Mathf.Abs(jumpForce) : Mathf.Abs(jumpForce);
    }
}
