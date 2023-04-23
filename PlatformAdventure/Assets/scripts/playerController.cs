using UnityEngine;
using UnityEngine.UI ; 

public class playerController : MonoBehaviour
{
  public float horizontalSpeed ; 
  public float jumpSpeed ; 

  private Rigidbody2D rb ; 

  private bool isright = true ; 

  private Animator anim ; 
public int Health ; 
public int MaxHealth = 5 ; 
  // is grounded functionality 

  private bool isgrounded ; 
  public Transform groundpos ; 
  public float checkRadius ; 
  public LayerMask whatIsMask ; 

  // ladder 

  private bool isclimbing ; 
  public float distance ; 

  public LayerMask whatisladder ; 

  // HealthBar 

  public HealthBar healthBar ; 
  private bool isDead = false ; 

  private int minHealth =>  50 * MaxHealth  / 100 ; 

  public SceneTransition scenetransition ; 

  // UI 

  public Text scoreText ; 


  

  private void Start() 
  {
    healthBar.SetMaxHealth(MaxHealth); 
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
    if(this.transform.position.y <= -9.8)
    {
      isDead = true ; 
      scenetransition.setScene("GameOver"); 

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
    healthBar.SetHealth(Health);

    if(Health<=minHealth)
    {
        healthBar.SetDanger() ; 
    }
    else if(Health >= minHealth)
    {
      healthBar.NoDanger() ; 
    }
    
    if(Health<=0)
    {
        Destroy(this.gameObject);
        isDead = true ; 
        scenetransition.setScene("GameOver"); 

    }

}

public void GetHealth(int HealthAmt) 
{
  healthBar.SetHealth(Health);
  Health += HealthAmt ; 
}

int score ; 
private void OnTriggerEnter2D(Collider2D collider)
{
  if(collider.CompareTag("fruit"))
  {
  // int score = collider.GetComponent<CollectItem>().score ; 
    score ++ ; 
    scoreText.text = score + "Points".ToString() ; 
    Destroy(collider.gameObject);
  }

 else if(collider.CompareTag("flag"))
  {
    Debug.Log("Hello"); 
    scenetransition.setScene("Win");
  }
}
}
