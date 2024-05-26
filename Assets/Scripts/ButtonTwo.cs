using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTwo : MonoBehaviour
{
    public BladeEnemy[] blades; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (BladeEnemy blade in blades)
            {
                blade.StopRotation();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (BladeEnemy blade in blades)
            {
                blade.ResumeRotation();
            }
        }
    }
}
