using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerHealth : Health
{

    public void HpLostByWeapon(Collider other, PlayerController player)
    {
        if (other.tag == "Weapon")
        {
            player.takeDamage.CheckDamage(other, player.playerHealth);

            player.healthBar.SetSize(player.playerHealth.CurrentHp / player.playerHealth.MaxHp);
        }
    }

    public void HpRestore(Collider other, PlayerController player)
    {

        if (other.tag == "Healing")
        {
            player.getHp.Heal(other, player.playerHealth); 

            player.healthBar.SetSize(player.playerHealth.CurrentHp / player.playerHealth.MaxHp);

        }
    }
   
}

