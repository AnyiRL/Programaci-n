using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public bool value;   // si la accion se cumple o no 
    public abstract bool Check(GameObject owner);   //ejecutar la accion de la condicion 
}
