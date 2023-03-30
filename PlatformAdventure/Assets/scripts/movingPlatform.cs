using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float speed ; 
   public Transform[] points ; 
   public int startPoint = 0 ; 

   private int index ; 

  private void Start() 
   {
    transform.position = points[startPoint].position ; 
   }

   private void Update() 
   {
        if(Vector2.Distance(transform.position,points[index].position) < 0.02f)
        {
            index++ ; 
            if(index==points.Length)
            {
                index = 0 ; 
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,points[index].position,speed*Time.deltaTime);
   }

void OnCollisionEnter2D(Collision2D collision) 
{
    Debug.Log("Hi All ");
    if(collision.gameObject.CompareTag("Player"))
    {
    collision.transform.SetParent(transform) ; 
    }
}
void OnCollisionExit2D(Collision2D collision) 
{
    collision.transform.SetParent(null) ; 
}




}
