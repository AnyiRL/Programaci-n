using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;
    private HearAction actionDraw;
    private void Start()
    {
        currentState = initialState;
        actionDraw = GetComponent<HearAction>();
    }

    private void Update()
    {
        State nextState = currentState.Run(gameObject);
        if (nextState)
        {
            currentState = nextState;
        }
        actionDraw.OnDrawGizmos(gameObject);
    }
    // llamar el OnDrawGizmos
}
