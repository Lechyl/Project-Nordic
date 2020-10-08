using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RepairWeapon : ScriptableObject
{
    public void DurabilityRegain(Collider durabilityRestore, Weapons weponsDurability)
    {
        Repair repair = durabilityRestore.GetComponent<Repair>();

        float DurabilityRestoreAmount = repair.RepairWeapon;

        float sum = weponsDurability.durability += DurabilityRestoreAmount;

        if(sum > weponsDurability.maxDurability)
        {
            weponsDurability.durability = weponsDurability.maxDurability;
        }
    }
}
