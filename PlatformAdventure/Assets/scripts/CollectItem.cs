using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int score ; 
   private void OnTriggerEnter2D(Collider2D col) {
    if(col.CompareTag("Player"))
    {
        
        Debug.Log("hi Score is "+score);
        // Destroy(this.gameObject); 
    }
   }
}
