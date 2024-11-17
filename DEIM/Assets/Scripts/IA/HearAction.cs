using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HearAction (A)", menuName = "ScriptableObject/Action/HearAction")]
public class HearAction : Action
{
    public float radius = 20f;
    private float currentTime = 0;
    private float maxTime = 4;
    public AudioClip AClip;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius,Vector3.up);
        GameObject target = owner.GetComponent<TargetReference>().target;
        currentTime += Time.deltaTime;
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject == target)
            {
                if (currentTime > maxTime)
                {
                    AudioManager.instance.PlayAudio(AClip, "HelloSound");
                    currentTime = 0;
                }
                return true;
            }
        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, radius);  //la esfera para escuchar
    }
}
