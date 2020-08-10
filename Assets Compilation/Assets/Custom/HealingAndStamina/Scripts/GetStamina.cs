using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class GetStamina : ScriptableObject
{

    public void StaminaRegain(Collider StaminaRestore, PlayerStamina playerStamina)
    {

        Stamina stamina = StaminaRestore.GetComponent<Stamina>();

        float StaminaRestoreAmount = stamina.RestoreStamina;

        float sum = playerStamina.CurrentStamina += StaminaRestoreAmount;

        if (sum > playerStamina.MaxStamina)
        {
            playerStamina.CurrentStamina = playerStamina.MaxStamina;
        }


    }

}
