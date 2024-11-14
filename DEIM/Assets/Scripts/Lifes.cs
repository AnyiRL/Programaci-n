using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    private int valor = 1;

    private void OnTriggerEnter(Collider collision)
    {
        PlayerMovementCC PMComponent = collision.gameObject.GetComponent<PlayerMovementCC>();

        if (PMComponent != null)
        {
            GameManager.instance.QuitLifes(valor);
        }

    }
}
