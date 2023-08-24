using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] GameObject _levelLostCanvas;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Time.timeScale = 0f;
        _levelLostCanvas.SetActive(true);
    }
}
