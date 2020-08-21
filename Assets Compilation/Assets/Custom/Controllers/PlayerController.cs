using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public FloatReference currentHp;
    //public FloatReference maxHp;
    //public FloatReference moveSpeed;

    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public TakeDamage takeDamage;
    public GetHp getHp;
    public GetStamina getStamina;
    public PlayerStats playerStats;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public StaminaBar staminaBar;

    private void Start()
    {
        healthBar.SetSize();
       

    }

    private void Update()
    {
        // test for staminaBar
        if (playerStamina.CurrentStamina > 0)
        {
            playerStamina.CurrentStamina -= playerStamina.StaminaRegen * Time.deltaTime;
            staminaBar.SetSize();
        }
    }






    // must be on Enemy and player controller
    private void OnTriggerEnter(Collider other)
    {
        // For taking dmg 
        playerHealth.HpLostByWeapon(other,this);
        // For healing
        playerHealth.HpRestore(other,this);

        playerStamina.StaminaRestore(other, this); 
    }



}
