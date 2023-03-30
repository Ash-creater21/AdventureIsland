using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int Health ; 
   public float speed ; 
   public void TakeDamage(int DamageAmt)
   {
    Health -= DamageAmt ; 
    if(Health<=0)
    {
        Destroy(gameObject);
    }
   }
}
