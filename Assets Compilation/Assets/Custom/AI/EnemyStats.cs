using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed = 1;
    public float lookRange = 40f;
    public float lookSphereCastRadius = 1f;
    public float attackRange = 2f;
    public float attackSpeed = 2f;
    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;
}
