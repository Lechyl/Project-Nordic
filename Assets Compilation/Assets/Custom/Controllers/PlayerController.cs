using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public FloatReference currentHp;
    //public FloatReference maxHp;
    //public FloatReference moveSpeed;
    public PlayerHealth playerHealth;
    public PlayerStamina playerStamina;
    public TakeDamage takeDamage;
    public GetHp getHp;
    public GetStamina getStamina;
    public PlayerStats playerStats;
    public List<Quest> quest;


    [SerializeField] public HealthBar healthBar;
    [SerializeField] public StaminaBar staminaBar;

    private void Start()
    {
        healthBar.SetSize();


    }

    private void Update()
    {
        // test for staminaBar
        if (playerStats.CurrentStamina <= playerStats.MaxStamina)
        {
            playerStats.CurrentStamina += playerStats.StaminaRegen * Time.deltaTime;
            staminaBar.SetSize();
        }

        HotbarPress();

    }


    void HotbarPress()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HotBarActions(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HotBarActions(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HotBarActions(2);
        }

    }
    void HotBarActions(int slot)
    {
        InventoryStackItems stackItem = Inventory.instance.hotbarList.hotbarList[slot];

        if (stackItem.item.GetType() != typeof(NoItem))
        {

            if (stackItem.item.GetType() == typeof(Healing))
            {

                playerHealth.HpRestore(stackItem, this);

            }
            else if (stackItem.item.GetType() == typeof(Stamina))
            {
                playerStamina.StaminaRestore(stackItem, this);

            }
            else if (stackItem.item.GetType() == typeof(Stone))
            {
                // stone function

            }
            Inventory.instance.hotbarList.UseConsumableItem(slot);
            Inventory.instance.UpdateHotbarSlots();
        }

    }


    // must be on Enemy and player controller
    private void OnTriggerEnter(Collider other)
    {
        // For taking dmg 
        playerHealth.HpLostByWeapon(other, this);


    }



}
