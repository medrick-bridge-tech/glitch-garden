using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarPresenter : MonoBehaviour
{
    private Text _starText;
    private int _stars = 100;
    public enum Status {SUCCESS, FAILURE};

  
    void Start () {
        _starText = GetComponent <Text>();
        UpdateDisplay();
    }
	
    public void AddStars(int amount) 
    {
        _stars += amount;
        UpdateDisplay();
    }
	
    public Status ConsumeStars(int amount) 
    {
        if (_stars >= amount) {
            _stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
	
    private void UpdateDisplay()
    {
        _starText.text = _stars.ToString();
    }
    
    public bool HasEnoughStars(int defenderCost)
    {
        return _stars >= defenderCost ? true : false;
    }
}
