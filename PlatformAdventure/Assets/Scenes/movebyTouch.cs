using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebyTouch : MonoBehaviour
{
  void Update() 
  {
    if(Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0); 

       Vector3 touchposition =  Camera.main.ScreenToWorldPoint(touch.position);
       transform.position = touchposition ; 
    }
  }
}
