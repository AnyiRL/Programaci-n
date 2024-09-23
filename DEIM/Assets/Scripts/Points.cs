using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int valor = 1;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementCC>() != null)
        {
            Destroy(gameObject);
            GameManager.instance.AddPoints(valor);
        }
    }
}
