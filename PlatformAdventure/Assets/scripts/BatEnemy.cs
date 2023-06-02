using System.Collections;
using UnityEngine;

public class BatEnemy : Enemy
{
    public float stopDistance ; 
    
    // would store EXact time of attack 
   public float attackTime ; 

   public ParticleSystem DeathEffect ; 

  



    public void Update() 
    {
        if(player!=null)
        {
            if(Vector2.Distance(transform.position,player.position)>stopDistance)
            {
                
                transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
            }
            else 
            {
                // we are ready to attack ! 
                if(Time.time>=attackTime)
                {
                    StartCoroutine(Attack()) ; 
                    attackTime = Time.time + timebtwAttacks ; 
                }
            }
        }
    }

     IEnumerator Attack() 
     {
        player.GetComponent<playerController>().TakeDamage(DamageAmt); 
        Vector2 orignalpos = this.transform.position ; 
        Vector2 targetpos = player.position ; 
        float percent = 0 ; 
        while(percent<=1)
        {
            percent+= Time.deltaTime * attackTime ; 
            float formula = (-Mathf.Pow(percent,2) + percent * 4) ; 
            transform.position = Vector2.Lerp(orignalpos,targetpos,formula);
            yield return null ; 
        }
     }


    public new void TakeDamage(int DamageAmt)
   {
    Health -= DamageAmt ; 
    Instantiate(DeathEffect,this.transform.position,this.transform.rotation);
    
    if(Health<=0)
    {
        Destroy(this.gameObject);
    }
   }
}
