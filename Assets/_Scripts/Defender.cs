using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int starCost = 100;
	
    private StarDispaly starDisplay;

    void Start () {
        starDisplay = GameObject.FindObjectOfType<StarDispaly>();
    }
	
    // Only being used as a tag for now!
    public void AddStars (int amount) {
        starDisplay.AddStars (amount);
    }
}

