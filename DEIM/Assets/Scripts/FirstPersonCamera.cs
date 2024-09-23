using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSens;
    public Transform playerTransform;

    private float mouseYRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    //.confined para que el cursor no salga de la pantalla de juego, .locked es para que el cursor desaparezaca cuando pulses la pantalla 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
       
        mouseYRotation -= mouseY;

        if (mouseYRotation < 90 && mouseYRotation > -90)
        {
            transform.localEulerAngles = Vector3.right * mouseYRotation;       //angulos normales y lo modifica por dentro
        }
        mouseYRotation = Mathf.Clamp(mouseYRotation, -90, 90);

        playerTransform.Rotate(Vector3.up * mouseX);         
    }
}
