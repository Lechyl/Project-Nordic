using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RepairWeapon : ScriptableObject
{
    public Wepons playerWepon;
    public EquipmentList equipmentList;

    public void DurabilityRegain(InventoryStackItems repairItem)
    {

        Repair repair = repairItem.item.GetComponent<Repair>();
        if (equipmentList.Wepons != null)
        {
            playerWepon = (Wepons)equipmentList.Wepons;
            Debug.Log(playerWepon);

            if(playerWepon.durability != playerWepon.maxDurability)
            {
                float DurabilityRestoreAmount = repair.RepairWeapon;

                float sum = playerWepon.durability += DurabilityRestoreAmount;

                if(sum > playerWepon.maxDurability)
                {
                    playerWepon.durability = playerWepon.maxDurability;
                } else
                {
                    playerWepon.durability = sum;
                }
            }

        }

    }
}
