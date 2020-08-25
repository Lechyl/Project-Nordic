using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public AttackAction attack;
    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public List<Transform> wayPointList;
    public State remainState;
    public AiHealth aiHealth;
    public TakeDamage takeDamage;
    public PlayerStats playerStats;
    public bool canDespawn;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    private bool aiActive;
    public float CurrentHp;
    public float MaxHp;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetupAI(true);



        // set weapon stats scaling with player level 

    }
    // Update is called once per frame
    void Update()
    {
        if (!aiActive)
        {
            return;
        }
        //This emphitise that you use this instance of statecontroller
        currentState.UpdateState(this);
    }

    public void SetupAI(bool aiActivationFromTankManager)
    {
        
        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            setRagdollRigidbodyState(true);
            setRagdollColliderState(false);
            canDespawn = true;
            agent.enabled = true;
            eyes.GetChild(0).gameObject.GetComponent<Wepons>().lvl = playerStats.Level;
            eyes.GetChild(0).gameObject.GetComponent<Wepons>().dmg = playerStats.Level * 10;
            MaxHp = MaxHp * playerStats.Level / 2;
            CurrentHp = MaxHp;
        }
        else
        {
            agent.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
            OnExitState();

        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    public void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // For taking dmg 
        // playerHealth.HpLostByWeapon(other, this);
       aiHealth.HpLostByWeapon(other,this);
    }


    public void setRagdollRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = transform.GetChild(1).GetComponentsInChildren<Rigidbody>();

        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

    }

    public void setRagdollColliderState(bool state)
    {
        Collider[] colliders = transform.GetChild(1).GetComponentsInChildren<Collider>();

        foreach (var collider in colliders)
        {
            collider.enabled = state;
           // collider.isTrigger = state;
        }
    }


    public void setEnemyAsDeadState()
    {
        Collider[] colliders = transform.GetChild(1).GetComponentsInChildren<Collider>();

        foreach (var collider in colliders)
        {
             collider.enabled = true;
            collider.isTrigger = true;
            collider.tag = "Interact";
        }
    }
}
