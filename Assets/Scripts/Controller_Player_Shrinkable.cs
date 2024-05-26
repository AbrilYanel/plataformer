using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Shrinkable : Controller_Player
{
    private bool isShrinking = false;
    private Vector3 originalScale;
    public float shrinkFactor = 0.5f;
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate(); // Llamar al FixedUpdate de la clase base para manejar el movimiento y la lógica de salto

        if (GameManager.actualPlayer == playerNumber)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isShrinking = true;
                Shrink();
            }
            else
            {
                isShrinking = false;
                RestoreSize();
            }
        }
    }

    private void Shrink()
    {
        if (!isShrinking) return;
        transform.localScale = originalScale * shrinkFactor;
    }

    private void RestoreSize()
    {
        transform.localScale = originalScale;
    }
}
