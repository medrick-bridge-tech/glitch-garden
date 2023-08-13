using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Defenders : MonoBehaviour
{

   public void FireProjectile()
   {
      GetComponent<Projectile>().FireProjectile();
   }
}
