using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Health health;
    public Image fillImage;
    private Slider slider; 



    private void Awake()
    {
        slider = GetComponent<Slider>(); 
    }

    public void SetSize()
    {

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false; 
        }
        if (slider.value > slider.minValue && !fillImage.enabled )
        {
            fillImage.enabled = true;

        }

        float fillvalue = health.CurrentHp / health.MaxHp;
        slider.value = fillvalue; 


            /*
        if(bar.localScale.x <= 0.0 )
        {
            bar.localScale = new Vector3(0, 1f);
        }
        else
        {
            bar.localScale = new Vector3(sizeNormalized, 1f);
        }
            */

    }


}
