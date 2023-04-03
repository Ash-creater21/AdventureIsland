using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int fruitHealth = 2 ; 
    private playerController player ; 
    void Start() 
    {
        player = GetComponent<playerController>() ; 
    }
    
   private void OnTriggerEnter2D(Collider2D col) {
    if(col.CompareTag("fruit"))
    {
        
        player.GetHealth(fruitHealth);
        Destroy(col.gameObject); 
    }
   }
}
