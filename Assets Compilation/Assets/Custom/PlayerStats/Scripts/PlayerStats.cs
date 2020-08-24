using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    //public float height = 10.0f;
    //Player level
    public float Level;
    public float Exp;
    public float ExpToLevel;


    //Player stats
    public float CurrentStamina;
    public float MaxStamina;
    public float StaminaRegen;

    //PlayerMovement
    public float WalkSpeed = 12f;
    public float SprintSpeed = 20f;

    //GravityStats
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    public float groundDistance = 0.4f;

    //MouseMovement
    public float mouseSentitivity = 200f;


}
