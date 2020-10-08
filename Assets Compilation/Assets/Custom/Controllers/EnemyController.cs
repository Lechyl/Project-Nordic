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
    public float DespawnAfterDeathTime;
    public float timeForNewPath;
    public bool inCoRoutine = false;
    public float callAlliesRadius;

    public List<Quest> partOfQuest;
    public QuestLog questlog; 

    [HideInInspector] public bool callCloseAllies = false;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    private bool aiActive;
    public float CurrentHp;
    public float MaxHp;
    public int deathExp = 0;


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
            SetRagdollRigidbodyState(true);
            SetRagdollColliderState(false);
            canDespawn = true;
            agent.enabled = true;

            // skal rettes til player weapons nye sted
            //eyes.GetChild(0).gameObject.GetComponent<Wepons>().lvl = playerStats.level;
            //eyes.GetChild(0).gameObject.GetComponent<Wepons>().dmg = playerStats.level * 10;
            MaxHp = MaxHp * playerStats.level / 2;
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
            callCloseAllies = false;

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


    public void SetRagdollRigidbodyState(bool state)
    {
        if (agent != null)
        {

            Rigidbody[] rigidbodies = transform.GetChild(1).GetComponentsInChildren<Rigidbody>();

            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = state;
            }
        }

    }

    public void SetRagdollColliderState(bool state)
    {
        if (agent != null)
        {
            Collider[] colliders = transform.GetChild(1).GetComponentsInChildren<Collider>();

            foreach (var collider in colliders)
            {
                collider.enabled = state;
                // collider.isTrigger = state;
            }
        }
    }


    public void SetEnemyAsDeadState()
    {
        if (agent != null)
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
}
