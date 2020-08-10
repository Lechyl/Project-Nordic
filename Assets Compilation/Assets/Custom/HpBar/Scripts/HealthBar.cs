using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar; 

    private void Awake()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
 
        if(bar.localScale.x <= 0.0 )
        {
            bar.localScale = new Vector3(0, 1f);
        }
        else
        {
            bar.localScale = new Vector3(sizeNormalized, 1f);
        }


    }


}
