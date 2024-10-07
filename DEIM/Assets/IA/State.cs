using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateParameter
{
    [Tooltip("Indicate fi tha action´s check must be true or false")]
    public bool actionValue;
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("If the action´s check equals actionValue, nextState is pushed")]
    public State nextState;

}
public abstract class State : ScriptableObject           
{
    public StateParameter[] StateParameter;
    public State[] nextStates;
    public Action[] actions;
    // public Action [] actions;

    //private bool ChecksActions()
    //{
    //    //devolver true si alguna de sus acciones se cumple, o false si es al contrairio
    //}
    public abstract State Run(GameObject owner);

}
