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

  // is grounded functionality 

  private bool isgrounded ; 
  public Transform groundpos ; 
  public float checkRadius ; 
  public LayerMask whatIsMask ; 



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
    Debug.Log(isgrounded);

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


  }

  private void Update() 
  {

    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    {
        rb.velocity = Vector2.up * jumpSpeed ; 
    }
  }

private void flip() 
{
    isright = !isright ; 

    Vector3 Scaler = this.transform.localScale ; 
    Scaler.x *= -1 ; 
    this.transform.localScale = Scaler ; 
}

}
