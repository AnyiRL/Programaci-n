using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateParameter
{
    [Tooltip("Indicate if the action�s check must be true or false")]
    public bool actionValue;
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("If the action�s check equals actionValue, nextState is pushed")]
    public State nextState;

}
public abstract class State : ScriptableObject           
{
    public StateParameter[] StateParameter;
    public State[] nextStates;
    //public Action[] actions;

    //private bool ChecksActions()//devolver true si alguna de sus acciones se cumple, o false si es al contrairio
    //{
    //    for (int i = 0; i < StateParameter.Length; ++i)
    //    {
    //        if (StateParameter[i].actionValue == true)
    //        {
    //            return true;
    //        }         
    //    }
    //}
    public abstract State Run(GameObject owner);

}