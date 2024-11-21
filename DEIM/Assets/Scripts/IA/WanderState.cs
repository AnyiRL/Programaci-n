using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "WanderState (S)", menuName = "ScriptableObject/State/WanderState")]
public class WanderState : State
{
    public float maxTime;
    public float radius;
    private float currentTime;
    public override State Run(GameObject owner)
    {
        State nextState = ChecksActions(owner);
        currentTime += Time.deltaTime;
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        bool pointFound = false;
        if (currentTime >= maxTime)
        {
            do
            {
                Vector3 randomPoint = owner.transform.position + Random.insideUnitSphere * radius;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(hit.position);
                    pointFound = true;
                }
            } while (!pointFound);
            currentTime = 0;
        }     
        return nextState;
    }

    
}
