using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    private Button[] buttonArray;
    public static GameObject selectDefender;
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectDefender = defenderPrefab;
    }
}
