using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public FloatReference currentHp;
    //public FloatReference maxHp;
    //public FloatReference moveSpeed;

    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public TakeDamage takeDamage;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private StaminaBar staminaBar;

    private void Start()
    {
        healthBar.SetSize(playerHealth.CurrentHp / playerHealth.MaxHp);
        staminaBar.SetSize(playerStamina.CurrentStamina/ playerStamina.MaxStamina);

    }

    private void Update()
    {
        // test for staminaBar
        if (Input.GetMouseButtonDown(0))
        {
            if (playerStamina.CurrentStamina > 0)
            {
                playerStamina.CurrentStamina--;
                staminaBar.SetSize(playerStamina.CurrentStamina / playerStamina.MaxStamina); 
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
