using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    //public float height = 10.0f;
    //Player level
    public int level;
    public int exp;
    public int expToLevel;


    //Player stats
    public ScriptableObject playerHp; 
    public float currentStamina;
    public float maxStamina;
    public float staminaRegen;

    //PlayerMovement
    public float walkSpeed = 12f;
    public float sprintSpeed = 20f;

    //GravityStats
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    public float groundDistance = 0.4f;

    //MouseMovement
    public float mouseSentitivity = 200f;

    public void GainExp(int exp_amount)
    {
        exp += exp_amount;

        while (exp > expToLevel)
        {
            exp -= expToLevel;

            LevelUp();
        }


    }

    public void LevelUp()
    {
        //Level up Logic here.
        level++;
        expToLevel *= 2;

    }
}
