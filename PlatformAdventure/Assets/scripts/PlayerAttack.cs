using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   private float timebtwAttack ; 

   public float startTimebtwAttack ; 

   public Transform Attackpos ; 
   public float AttackRadius ; 

   public LayerMask whatIsEnemy ; 

   public int Damage ; 

   private Animator anim ; 

   private void Start()
   {
        anim = GetComponent<Animator>();
   }

   private void Update() 
   {
    if(timebtwAttack<=0)
    {
        timebtwAttack = startTimebtwAttack ; 
    }
    else 
    {
        timebtwAttack -= Time.deltaTime ; 
    }
    if(Input.GetKeyDown(KeyCode.Space))
    {
        // attack Animation 
        anim.SetTrigger("Attack") ; 
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(Attackpos.position,AttackRadius,whatIsEnemy); 

        for(int i = 0 ; i<EnemiesToDamage.Length ; i++)
        {
            EnemiesToDamage[i].GetComponent<PlantEnemy>().TakeDamage(Damage);
        }


    }
   
   }
private void OnDrawGizmosSelected() 
   {
    Gizmos.color = Color.red ; 
    Gizmos.DrawWireSphere(Attackpos.position,AttackRadius);
   }
}
