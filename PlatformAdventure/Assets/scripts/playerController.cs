using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
  public float horizontalSpeed ; 
  public float jumpSpeed ; 

  private Rigidbody2D rb ; 

  private bool isright = true ; 

  private Animator anim ; 
public int Health = 10 ; 

  // is grounded functionality 

  private bool isgrounded ; 
  public Transform groundpos ; 
  public float checkRadius ; 
  public LayerMask whatIsMask ; 

  // ladder 

  private bool isclimbing ; 
  public float distance ; 

  public LayerMask whatisladder ; 

  

  private void Start() 
  {
    anim = GetComponent<Animator>(); 
    rb = GetComponent<Rigidbody2D>(); 
  }

  private void FixedUpdate() 
  {
    float moveinput = Input.GetAxisRaw("Horizontal"); 

    rb.velocity = new Vector2(moveinput*horizontalSpeed,rb.velocity.y);

    if(moveinput > 0 && isright == true)
    {
        flip() ; 
    }
    else if(moveinput < 0 && isright == false )
    {
        flip() ; 
    }
  // Ground Check 

  isgrounded = Physics2D.OverlapCircle(groundpos.position,checkRadius,whatIsMask); 
    // Animatation Handling 
    // Debug.Log(isgrounded);

    if(moveinput == 0)
    {
      anim.SetBool("isrunning",false);
    }
    else 
    {
      anim.SetBool("isrunning",true);
    }
    if(isgrounded==true)
    {
      anim.SetBool("isjumping",false) ; 
    }
    else if(isgrounded==false)
    {
      anim.SetBool("isjumping",true) ; 
    }


    RaycastHit2D hitinfo = Physics2D.Raycast(transform.position,Vector2.up,distance,whatisladder);

    if(hitinfo.collider!=null)
    {
      if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
      {
        isclimbing = true ; 
      }
      
    }
    else 
      {
        isclimbing = false ; 
      }
   if(isclimbing==true)
    {
      float inputVertical = Input.GetAxis("Vertical"); 
      rb.velocity = new Vector2(rb.velocity.x,inputVertical*jumpSpeed) ; 
      rb.gravityScale = 0 ; 
    }
    else 
    {
      rb.gravityScale = 3 ; 
    }
   
  }

  private void Update() 
  {
    if(isclimbing==false)
    {
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    {
        rb.velocity = Vector2.up * jumpSpeed ; 
    }
    }
   
  }

private void flip() 
{
    isright = !isright ; 

    Vector3 Scaler = this.transform.localScale ; 
    Scaler.x *= -1 ; 
    this.transform.localScale = Scaler ; 
}

 public void TakeDamage(int DamageAmt)
   {
    Health -= DamageAmt ; 
    
    
    if(Health<=0)
    {
        Destroy(this.gameObject);
    }

}

public void GetHealth(int HealthAmt) 
{
  Health += HealthAmt ; 
}


}
