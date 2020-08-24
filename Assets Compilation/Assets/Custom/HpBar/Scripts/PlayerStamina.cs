using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class PlayerStamina : ScriptableObject
{

    public void StaminaRestore(Collider other, PlayerController player)
    {

        if (other.tag == "Stamina")
        {

            player.getStamina.StaminaRegain(other, player.playerStats);

            player.staminaBar.SetSize();

        }

    }

   

}