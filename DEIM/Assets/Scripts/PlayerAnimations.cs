using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovementCC playerMovementCC;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovementCC = GetComponent<PlayerMovementCC>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        //bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        //if (x!=0 || z != 0)
        //{
        //    // se esta moviemdo 
        //    if (shiftPressed)
        //    {
        //        //y esta corriendo
        //        animator.SetBool("isRunning", true);
        //        animator.SetBool("isWalking", false);
        //    }
        //    else
        //    {
        //        //y esta andando
        //        animator.SetBool("isRunning", false);
        //        animator.SetBool("isWalking", true);
        //    }
        //}
        //else
        //{
        //    //esta quieto
        //    animator.SetBool("isRunning", false);
        //    animator.SetBool("isWalking", false);
        //}
    }
    private void LateUpdate()
    {
        animator.SetFloat("Speed",playerMovementCC.GetCurrentSpeed() / playerMovementCC.runningSpeed);  //devuelve la longitud del vector
    }
}
