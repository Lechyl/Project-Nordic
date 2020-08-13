using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public FloatReference currentHp;
    //public FloatReference maxHp;
    //public FloatReference moveSpeed;

    public PlayerHealth playerHealth ; 

    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        healthBar.SetSize(playerHealth.CurrentHp / playerHealth.MaxHp);
        Debug.Log("SetSize"); 

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playerHealth.CurrentHp > 0)
            {
                playerHealth.CurrentHp--;
                healthBar.SetSize(playerHealth.CurrentHp / playerHealth.MaxHp); 
            }
        }
    }


}
