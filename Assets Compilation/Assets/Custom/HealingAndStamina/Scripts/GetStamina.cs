using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class GetStamina : ScriptableObject
{

    public void StaminaRegain(InventoryStackItems StaminaRestore, PlayerStats playerStamina)
    {

        Stamina stamina = StaminaRestore.item.GetComponent<Stamina>();

        float StaminaRestoreAmount = stamina.RestoreStamina;

        float sum = playerStamina.currentStamina += StaminaRestoreAmount;

        if (sum > playerStamina.maxStamina)
        {
            playerStamina.currentStamina = playerStamina.maxStamina;
        }


    }

}
