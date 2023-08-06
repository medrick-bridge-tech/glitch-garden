using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fadeElement : MonoBehaviour
{
    [SerializeField] float fadeTime;
    private Image panel;
    private Color CurrentColor = Color.black;

    void Start()
    {
        panel = GetComponent<Image>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeTime)
        {
            float alphaChange = Time.deltaTime / fadeTime;
            CurrentColor.a -= alphaChange;
            panel.color = CurrentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
