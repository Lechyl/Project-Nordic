using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class PlayerStamina : ScriptableObject
{

    public float CurrentStamina;
    public float MaxStamina;
    public float StaminaRegen;




    public void StaminaRestore(Collider other, Player player)
    {

        if (other.tag == "Stamina")
        {

            player.getHp.Heal(other, player.playerHealth);

            player.healthBar.SetSize(player.playerHealth.CurrentHp / player.playerHealth.MaxHp);

        }

    }
}