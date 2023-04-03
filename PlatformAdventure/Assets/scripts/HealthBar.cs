using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class HealthBar : MonoBehaviour
{
    public Slider slider ; 
    public Image fill ; 

    public Color Fillcolor ; 

    void Start() 
    {
        Fillcolor = fill.color ; 
        // fill = GetComponent<Image>() ; 
    }

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health ; 
        slider.value = Health ; 
    }

    public void SetHealth(int Health)
    {
        slider.value = Health ; 
    }
    public void SetDanger()
    {
        fill.color = Color.red ; 
    }
    public void NoDanger() 
    {
        fill.color = Fillcolor ; 
    }
   
}
