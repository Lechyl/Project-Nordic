using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public PlayerHealth playerHealth; 

  
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
            playerHealth.CurrentHp--; 
        

    }
}
