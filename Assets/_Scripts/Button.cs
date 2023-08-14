using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    private Button[] _buttonArray;
    public static GameObject selectedDefender;
    void Start () 
    {
        _buttonArray = GameObject.FindObjectsOfType<Button>();
    }
    void OnMouseDown () 
    {
        foreach (Button thisButton in _buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
