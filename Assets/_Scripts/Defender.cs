using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Defender : MonoBehaviour
{
    [SerializeField] private int _starCost = 100;
	
    private StarDispaly _starDisplay;

    public int StarCost => _starCost;

    
    void Start() 
    {
        _starDisplay = GameObject.FindObjectOfType<StarDispaly>();
    }
    
    public void AddStars(int amount) 
    {
        _starDisplay.AddStars(amount);
    }
}

