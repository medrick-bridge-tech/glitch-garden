using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private Defender _defenderPrefab;
    private Button[] _buttons;


    void Start () 
    {
        _buttons = GameObject.FindObjectsOfType<Button>();
    }

    void OnMouseDown () 
    {
        foreach (Button button in _buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(_defenderPrefab);
    }
}
