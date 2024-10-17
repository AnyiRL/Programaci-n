using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateParameter
{
    [Tooltip("Indicate if the action´s check must be true or false")]
    public bool[] actionsValues;
    [Tooltip("Action that is gonna be executed")]
    public Action[] actions;
    [Tooltip("If the action´s check equals actionValue, nextState is pushed")]
    public State nextState;
    [Tooltip("Se cumplen todas las acciones o solo se tiene que cumplir una")]
    public bool and;

}
public abstract class State : ScriptableObject           
{
    public StateParameter[] stateParameters;
    //public State[] nextStates;
    //public Action[] actions;

    protected State ChecksActions(GameObject owner)//devolver true si alguna de sus acciones se cumple, o false si es al contrairio
    {
        bool todasLasAccionesSeHanCumplido = true;
        for (int i = 0; i < stateParameters.Length; ++i) //recorre los parametros
        {
            for (int j = 0; j < stateParameters[i].actions.Length; j++)    //recorre las acciones de los parametros
            {
                
                if (stateParameters[i].actions[j].Check(owner) == stateParameters[i].actionsValues[j])    //Comprueba las acciones con los check
                {
                    if (!stateParameters[i].and)      //si solo se tiene que cumplir una 
                    {
                        //devolvemos directamente el siguiente 
                        return stateParameters[i].nextState;
                    }
                }
                else if (stateParameters[i].and)
                {
                    todasLasAccionesSeHanCumplido = false;
                    break;     //salimos del bucle porque una accion no se ha cumplido y estamos en and
                }
            }
            // si llegamos hasta aqui, significa que el diseñador ha marcado que todas las acciones tienen que cumplirse y, ademas, se han cumplido.
            // Tenemos que comprobar si de verdad se han cumplido todas
            if (stateParameters[i].and && todasLasAccionesSeHanCumplido)
            {
                return stateParameters[i].nextState;
            }
        }
        return null; // ninguna accion se cumple
    }
    public abstract State Run(GameObject owner);

    public void DrawAllACtionsGizmo(GameObject owner)
    {
        foreach (StateParameter parameter in stateParameters)
        {
            foreach(Action action in parameter.actions)
            {
                action.DrawGizmos(owner);
            }
        }
    }
}
