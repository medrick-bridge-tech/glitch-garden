using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DefenderSpawner : MonoBehaviour
{
   public Camera myCamera;
   private GameObject _parent;
   private void Start()
   {
      _parent = GameObject.Find("Defender");
      if (!_parent)
      {
         _parent = new GameObject("Defender");
      }
   }

   private void OnMouseDown()
   {
      Vector2 rawPos = CalculateWorldPointOfMouseClick();
      Vector2 roundedPos = SnapToGrid(rawPos);
      GameObject defender = Button.selectedDefender;
      Instantiate(defender,roundedPos, Quaternion.identity);
   }

   Vector2 SnapToGrid(Vector2 rawWorldPos)
   {
      float newX = Mathf.RoundToInt(rawWorldPos.x);
      float newY = Mathf.RoundToInt(rawWorldPos.y);
      return new Vector2(newX, newY);
   }
   Vector2 CalculateWorldPointOfMouseClick()
   {
      float mouseX = Input.mousePosition.x;
      float mouseY = Input.mousePosition.y;
      float distanceFromCamera = 10f;

      Vector3 weirdTrplet = new Vector3(mouseX, mouseY, distanceFromCamera);
      Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTrplet);
      
      return worldPos;
   }
}
