using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ; 

public class SceneTransition : MonoBehaviour
{
   public Animator Transitionanim ; 
   public void setScene(string sceneName)
   {
    StartCoroutine(Transition(sceneName)) ; 
   }
   public void ExitApplication()
   {
    Application.Quit() ; 
   }
   IEnumerator Transition(string sceneName){
    Transitionanim.SetTrigger("end"); 
    yield return new  WaitForSeconds(1) ; 
    SceneManager.LoadScene(sceneName);
   }
}
