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
    public GetHp getHp;
    public GetStamina getStamina;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public StaminaBar staminaBar;

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




    //private void HpLostByWeapon(Collider other)
    //{
    //    takeDamage.CheckDamage(other, health); 

    //    healthBar.SetSize(health.CurrentHp / health.MaxHp);
    //}




    // must be on Enemy and player controller
    private void OnTriggerEnter(Collider other)
    {
        // For taking dmg 
        playerHealth.HpLostByWeapon(other,this);
        // For healing
        playerHealth.HpRestore(other,this);

        playerHealth.StaminaRestore(other, this); 
    }



}
