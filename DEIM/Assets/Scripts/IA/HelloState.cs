using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "HelloState (S)", menuName = "ScriptableObject/State/HelloState")]
public class HelloState : State
{
    public string blendParameter;
    
    public override State Run(GameObject owner)
    {

        State nextState = ChecksActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        animator.SetFloat(blendParameter, 1);

        return nextState;
    }
}
