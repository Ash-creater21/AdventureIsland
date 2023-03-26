using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
  public float horizontalSpeed ; 
  public float jumpSpeed ; 

  private Rigidbody2D rb ; 

  private bool isright = true ; 

  private void Start() 
  {
    rb = GetComponent<Rigidbody2D>() ; 
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
