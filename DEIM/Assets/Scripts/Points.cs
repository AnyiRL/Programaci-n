using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int rSpeed;

    private int valor = 100;
    
    void Update()
    {
        Vector3 rotation = new Vector3(0, rSpeed, 0) * Time.deltaTime;
        transform.Rotate(rotation); // rota a la direccion que se indica
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementCC>() != null)
        {
            Destroy(gameObject);
            GameManager.instance.AddPoints(valor);
        }
    }
}
