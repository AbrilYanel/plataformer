using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_button : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
           
            GameObject[] puertas = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject puerta in puertas)
            {
                Destroy(puerta);
            }
        }
    }
}
