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
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    private bool aiActive;

    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetupAI(true);
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
            agent.enabled = true;
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
}
