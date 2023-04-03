using UnityEngine;

public class PlantEnemy : Enemy
{
    private bool movingRight  = true ; 
    public Transform GroundDetection ;

    public int distance ; 

    public LayerMask whatisLayer ; 

    public GameObject prefab ; 

    public int damage = 1 ; 
    public ParticleSystem DeathEffect ; 


    // private void Start() 
    // {
    //     anim = GetComponent<Animator>();
    // }

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
    Instantiate(prefab,this.transform.position,this.transform.rotation);
    
    if(Health<=0)
    {
        Destroy(this.gameObject);
    }
   }

   void OnTriggerEnter2D(Collider2D collider) 
   {
        playerController player = collider.GetComponent<playerController>();
        // if(player!=null)
        // {
        //     Debug.Log("HUHU");
        //     player.TakeDamage(damage);
        // }
        if(collider.CompareTag("Player"))
        {
            Instantiate(DeathEffect,transform.position,transform.rotation) ; 
            int damage = 1 ;
            player.TakeDamage(damage);
        }

   }



}
