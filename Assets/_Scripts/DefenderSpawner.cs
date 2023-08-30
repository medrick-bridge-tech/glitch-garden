using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DefenderSpawner : MonoBehaviour
{
   [SerializeField] Camera _myCamera;
   [SerializeField] private GameObject _notEnoughStarsText;
   
   private GameObject _parent;
   private StarDispaly _starDispaly;
   private Defender _selectedDefender;
   
   
   
   private void Start()
   {
      _parent = GameObject.Find("Defender");
      _starDispaly = GameObject.FindObjectOfType<StarDispaly>();
      if (!_parent)
      {
         _parent = new GameObject("Defender");
      }
   }
   
   void Update()
   {
      if (_selectedDefender)
      {
         if (_starDispaly.HasEnoughStars(_selectedDefender.StarCost))
         {
            _notEnoughStarsText.SetActive(false);
         }
         else
         {
            _notEnoughStarsText.SetActive(true);
         }
      }
   }

   private void OnMouseDown()
   {
      Vector2 rawPos = CalculateWorldPointOfMouseClick();
      Vector2 roundedPos = SnapToGrid(rawPos);
      if (_selectedDefender)
      {
         int defenderCost = _selectedDefender.StarCost;
         
         if (_starDispaly.UseStars(defenderCost) == StarDispaly.Status.SUCCESS)
         {
            SpawnDefender(_selectedDefender, roundedPos);
         }
      }
   }

   private void SpawnDefender(Defender defender, Vector2 roundedPos)
   {
      var newDef = Instantiate(defender, roundedPos, Quaternion.identity);
      newDef.transform.parent = _parent.transform;
   }

   Vector2 SnapToGrid(Vector2 rawWorldPos)
   {
      float newX = Mathf.RoundToInt(rawWorldPos.x);
      float newY = Mathf.RoundToInt(rawWorldPos.y) - 0.5f;
      return new Vector2(newX, newY);
   }
   
   Vector2 CalculateWorldPointOfMouseClick()
   {
      float mouseX = Input.mousePosition.x;
      float mouseY = Input.mousePosition.y;

      Vector2 weirdTrplet = new Vector3(mouseX, mouseY);
      Vector2 worldPos = _myCamera.ScreenToWorldPoint(weirdTrplet);
      
      return worldPos;
   }
   
   public void SetSelectedDefender(Defender selectedDefender)
   {
      _selectedDefender = selectedDefender;
   }
}
