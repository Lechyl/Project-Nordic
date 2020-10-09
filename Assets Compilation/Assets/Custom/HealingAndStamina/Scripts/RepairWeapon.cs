using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RepairWeapon : ScriptableObject
{
    public Weapons playerWeapon;
    public EquipmentList equipmentList;

    public void DurabilityRegain(InventoryStackItems repairItem)
    {

        Repair repair = repairItem.item.GetComponent<Repair>();
        if (equipmentList.Wepons != null)
        {
            playerWeapon = (Weapons)equipmentList.Wepons;
            Debug.Log(playerWeapon);

            if (playerWeapon.durability != playerWeapon.maxDurability)
            {
                float DurabilityRestoreAmount = repair.RepairWeapon;

                float sum = playerWeapon.durability += DurabilityRestoreAmount;

                if (sum > playerWeapon.maxDurability)
                {
                    playerWeapon.durability = playerWeapon.maxDurability;
                }
                else
                {
                    playerWeapon.durability = sum;
                }
            }

        }

    }
}
