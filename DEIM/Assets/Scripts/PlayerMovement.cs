using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpForce, mouseSens, sphereRadius; //para que se pueda elegir la velocidad de rotacion    /* gravityScale*/;
    public string groundName;
    private Rigidbody rb;
    private float x, z, mouseX;  //input 
    private bool jumpPressed;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //gravityScale = -Mathf.Abs(gravityScale);   Abs valor absoluto   Math(f) para float
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");     // Raw para joystick, tiene valores maximos y minimos 
        z = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxisRaw("Mouse X");        //el raw se puede no poner, el valor es el mismo

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpPressed = true;
        }   // aqui no se pone false o sino el update lo "reincia"

        RotatePlayer();
    }

    void RotatePlayer()
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime;     //new Vector3(0, 5, 0) * Time.deltaTime  rotaci�n c
        transform.Rotate(rotation); // rota a la direccion que se indica
    }

    private void FixedUpdate()
    {
        ApplySpped();
        ApplyJumpForce();
    }

    void ApplySpped()
    {
        rb.velocity = (transform.forward * speed * z) + (transform.right * speed * x) + new Vector3(0, rb.velocity.y, 0); // la gravedad base de unity, todos tienen la misma 
        //  gravedad personalizada 
        // + (transform.up * gravityScale);   forward = eje z , right = eje x  ,  caida constante
        //rb.AddForce(transform.up * gravityScale);  tiene que estar abajo de velocidad, m�s realista 
    }

    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);  // reiniciar "y" para superar la fuerza de gravedad
            rb.AddForce(transform.up * jumpForce);
            jumpPressed = false;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit[] colliders = Physics.SphereCastAll(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius, Vector3.up); // se divide entre 2 la y para que la esfera este ene le suelo ,vector 3 no influye 

        for (int i = 0; i < colliders.Length; i++)  //recorremos elemento a elemento y comprobamos si es suelo 
        {
            if (colliders[i].collider.gameObject.layer == LayerMask.NameToLayer(groundName)) //   busca en que n de layer esta del nombrado y compara si es igual al del collider
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), sphereRadius);
    }
}
