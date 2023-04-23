using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
   public Transform particleEffect ; 
   public Transform player ; 

   public Vector3 offset ; 

   private void Update() 
   {
      // Instantiate(particleEffect);
      if(player!=null)
      {
    transform.position = player.position + offset; 
    particleEffect.position = this.transform.position + new Vector3(0.0f,0.0f,-0.7779132f); 
      }

   }
}
