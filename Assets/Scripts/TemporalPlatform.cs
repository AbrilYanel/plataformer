using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalPlatform : MonoBehaviour
{
    public float disappearTime = 2f; 
    public float appearTime = 2f;

    private Renderer platformRenderer;
    private Collider platformCollider;
    private bool isVisible = true;

    void Start()
    {
       
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider>();

        
        InvokeRepeating("ToggleVisibility", 0f, disappearTime + appearTime);
    }

    void ToggleVisibility()
    {
        isVisible = !isVisible; 

       
        platformRenderer.enabled = isVisible;
        platformCollider.enabled = isVisible;
    }
}
