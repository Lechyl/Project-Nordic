using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class PlayerStamina : ScriptableObject
{

    public void StaminaRestore(InventoryStackItems other, PlayerController player)
    {


            player.getStamina.StaminaRegain(other, player.playerStats);

            player.staminaBar.SetSize();

        

    }

   

}