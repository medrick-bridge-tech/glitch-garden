using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DefenderSpawner : MonoBehaviour
{
   public Camera myCamera;
   private GameObject _parent;
   private StarDispaly _starDispaly;
   private Defender _defender;
   [SerializeField] private GameObject _notEnoughStarsText;
   
   
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
      if (_defender)
      {
         if (_starDispaly.HasEnoughStars(_defender.StarCost))
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
      if (_defender)
      {
         int defenderCost = _defender.StarCost;
         
         if (_starDispaly.UseStars(defenderCost) == StarDispaly.Status.SUCCESS)
         {
            SpawnDefender(_defender, roundedPos);
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
      Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTrplet);
      
      return worldPos;
   }
   
   public void SetSelectedDefender(Defender selectedDefender)
   {
      _defender = selectedDefender;
   }
}
