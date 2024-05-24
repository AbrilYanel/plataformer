using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemy : MonoBehaviour
{
    public float upperLimit = 5.0f; 
    public float lowerLimit = -5.0f; 
    public float speed = 2.0f; 

    private bool movingDown = true;

    void Update()
    {
        
        if (movingDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= lowerLimit)
            {
                movingDown = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y >= upperLimit)
            {
                movingDown = true;
            }
        }
    }
   

}
