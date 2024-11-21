using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "PerseguirState (S)", menuName = "ScriptableObject/State/PerseguirState")]
public class PerseguirState : State
{
    public override State Run(GameObject owner)
    {
        State nextState = base.ChecksActions(owner); 

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        TargetReference target = owner.GetComponent<TargetReference>();  //.target si hay mas de uno 

        navMeshAgent.SetDestination(target.target.transform.position);
        return nextState;
    }
}
