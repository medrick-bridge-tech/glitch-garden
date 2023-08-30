using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class fadeElement : MonoBehaviour
{
    [SerializeField] float _fadeTime;
    
    private Image _panel;
    private Color _currentColor = Color.black;

    void Start()
    {
        _panel = GetComponent<Image>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad < _fadeTime)
        {
            float alphaChange = Time.deltaTime / _fadeTime;
            _currentColor.a -= alphaChange;
            _panel.color = _currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
