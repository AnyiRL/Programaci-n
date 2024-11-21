using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerLookAction (A)", menuName = "ScriptableObject/Action/PlayerLookAction")]
public class PlayerLookMe : Action
{ 
    
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().target;
        WhatImLooking whatImLooking = target.GetComponent<WhatImLooking>();
        List<GameObject> targetViewList = whatImLooking.viewList;

        foreach (GameObject objectInVision in targetViewList)
        {
            if(owner == objectInVision)
            {
                return true;
            }
        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        return;
    }
}

