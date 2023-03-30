using UnityEngine;

public class PlantEnemy : Enemy
{
    private bool movingRight  = true ; 
    public Transform GroundDetection ;

    public int distance ; 

    public LayerMask whatisLayer ; 

    private void Update() 
    {
 
        transform.Translate(Vector2.right * speed * Time.deltaTime);
  
   
        RaycastHit2D groundinfo = Physics2D.Raycast(GroundDetection.position,Vector2.down,distance,whatisLayer); 
        if(groundinfo.collider==false)
        {
            if(movingRight==true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false ; 

            }
            else 
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true ; 
            }
        }
    }

    public new void TakeDamage(int DamageAmt)
   {
    Health -= DamageAmt ; 
    if(Health<=0)
    {
        Destroy(this.gameObject);
    }
   }

}
