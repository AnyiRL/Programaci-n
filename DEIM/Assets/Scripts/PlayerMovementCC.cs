using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class PlayerMovementCC : MonoBehaviour
{
    public float speed, mouseSens, gravityScale, jumpForce;

    private float yVelocity = 0;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded) 
        {
            yVelocity = 0;       
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        
        Jump(jumpPressed);       
        Movement(x, z);
        //RotatePlayer(mouseX);
    }

    void Jump(bool jumpPressed)
    {
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale);   //raiz cuadrada
        }
    }

    void Movement(float x, float z)
    {
        Vector3 movementVector = transform.forward * speed * z + transform.right * speed * x;
        yVelocity -= gravityScale;
        movementVector.y = yVelocity;

        movementVector *= Time.deltaTime;           //mV = mV * Dt  para que se mueva igual en todos los ordenadores
        
        if(x != 0 || z!= 0)                   // codigo nyapa, borrar en el furuto 
        {
            characterController.Move(movementVector);
        }
    }
    
    void RotatePlayer(float mouseX)
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime;     //new Vector3(0, 5, 0) * Time.deltaTime  rotación c
        transform.Rotate(rotation); // rota a la direccion que se indica
    }

}
