using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class PlayerStamina : ScriptableObject
{

    public float CurrentStamina;
    public float MaxStamina;
    public float StaminaRegen;

  




    public void StaminaRestore(Collider other, PlayerController player)
    {

        if (other.tag == "Stamina")
        {

            player.getStamina.StaminaRegain(other, player.playerStamina);

            player.staminaBar.SetSize();

        }

    }

   

}