using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeEnemy : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private bool isStopped = false;

    void Update()
    {
        if (!isStopped)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }

    public void StopRotation()
    {
        isStopped = true;
    }

    public void ResumeRotation()
    {
        isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GameManager.gameOver = true;
        }
    }
}
