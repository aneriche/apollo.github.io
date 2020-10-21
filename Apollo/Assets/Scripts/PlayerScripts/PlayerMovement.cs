using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private CharacterController controller;
    public float playerSpeed = 1.0f;
    //private float jumpHeight = 1.0f;
    public Joystick joystick;
    private bool hasParent;
    private Vector3 lastParentPosition;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector3 parentMove = Vector3.zero;
        if (!(transform.parent is null))
        {
            if(hasParent == false)
            {
                hasParent = true;
                
            }
            else
            {
                parentMove = transform.parent.position - lastParentPosition;
            }
            lastParentPosition = transform.parent.position;
        }
        else
        {
            hasParent = false;
        }
        Vector3 move = new Vector3(joystick.Horizontal + Input.GetAxis("Horizontal"), 0, joystick.Vertical + Input.GetAxis("Vertical"));
        // Changes the height position of the player..
        /*if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }*/
        

        if (move != Vector3.zero) 
        {
            gameObject.transform.forward = move;
            controller.Move((move + parentMove) * Time.deltaTime * playerSpeed);

        }
        
    }
}
