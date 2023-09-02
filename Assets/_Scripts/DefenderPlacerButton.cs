using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderPlacerButton : MonoBehaviour
{
    [SerializeField] private Defender _defenderPrefab;
    
    private DefenderPlacerButton[] _buttons;


    void Start () 
    {
        _buttons = GameObject.FindObjectsOfType<DefenderPlacerButton>();
    }

    void OnMouseDown () 
    {
        foreach (DefenderPlacerButton button in _buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(_defenderPrefab);
    }
}
