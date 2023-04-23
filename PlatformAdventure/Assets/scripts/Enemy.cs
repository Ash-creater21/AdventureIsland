using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int Health ; 
   public float speed ; 

   public float timebtwAttacks ; 

   public int DamageAmt ; 
   
   public Transform player ; 

   private void Start() 
   {
     player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   public void TakeDamage(int DamageAmt)
   {
    Health -= DamageAmt ; 
    if(Health<=0)
    {
        Destroy(gameObject);
    }
   }
}
