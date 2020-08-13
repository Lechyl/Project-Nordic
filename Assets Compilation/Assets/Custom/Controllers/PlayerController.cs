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
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public StaminaBar staminaBar;

    private void Start()
    {
        healthBar.SetSize(playerHealth.CurrentHp / playerHealth.MaxHp);
       

    }

    private void Update()
    {
        // test for staminaBar
        if (playerStamina.CurrentStamina < 100)
        {
            playerStamina.CurrentStamina += playerStamina.StaminaRegen * Time.deltaTime;
            staminaBar.SetSize(playerStamina.CurrentStamina / playerStamina.MaxStamina);
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
