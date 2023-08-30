using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Defender : MonoBehaviour
{
    [SerializeField] private int _starCost = 100;
	
    private StarPresenter _starPresenter;

    public int StarCost => _starCost;

    
    void Start() 
    {
        _starPresenter = GameObject.FindObjectOfType<StarPresenter>();
    }
    
    public void AddStars(int amount) 
    {
        _starPresenter.AddStars(amount);
    }
}

