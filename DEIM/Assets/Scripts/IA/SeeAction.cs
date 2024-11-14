using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction (A)", menuName = "ScriptableObject/Action/SeeAction")]

public class SeeAction : Action
{
    public float radius;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    [Range(0, 360)]
    public float angle;
    public AudioClip HelloClip;

    public override bool Check(GameObject owner)
    {
        Collider[] rangeChecks = Physics.OverlapSphere(owner.transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - owner.transform.position).normalized;

            if (Vector3.Angle(owner.transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(owner.transform.position, target.position);

                if (!Physics.Raycast(owner.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                   // AudioManager.instance.PlayAudio(HelloClip, "HelloSound");
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        else
           return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        //FieldOfViewEditor foveditor = owner.GetComponent<FieldOfViewEditor>();
        //foveditor.tra = owner.transform;
        //foveditor.angle = angle;
        //foveditor.target = owner.GetComponent<TargetReference>().target;
        //foveditor.radius = radius;
        //return;
    //    FieldOfView fov = (FieldOfView)target;
    //    Handles.color = Color.white;
    //    Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

    //    Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
    //    Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);
    //    Handles.color = Color.yellow;
    //    Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
    //    Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

    //    if (true)
    //    {
    //        Handles.color = Color.green;
    //        Handles.DrawLine(fov.transform.position, owner.transform.position);
    //    }
    //}
    //private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    //{
    //    angleInDegrees += eulerY;
    //    return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
