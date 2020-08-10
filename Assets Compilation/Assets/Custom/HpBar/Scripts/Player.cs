using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public FloatReference currentHp;
    //public FloatReference maxHp;
    //public FloatReference moveSpeed;

    public PlayerHealth playerHealth;
    public TakeDamage takeDamage;
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

            }
        }
    }
    private void ChangeHp(float damage)
    {

        playerHealth.CurrentHp -= damage;


        healthBar.SetSize(playerHealth.CurrentHp / playerHealth.MaxHp);


    }

    // must be on Enemy and player controller
    private void OnTriggerEnter(Collider other)
    {
        // For taking dmg 
        if (other.tag == "Test")
        {
           
           ChangeHp (takeDamage.CheckDamage(other));



        }
        
    }



}
