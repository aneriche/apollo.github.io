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

        Vector3 move = new Vector3(joystick.Horizontal + Input.GetAxis("Horizontal"), 0, joystick.Vertical + Input.GetAxis("Vertical"));
        // Changes the height position of the player..
        /*if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }*/

        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero) 
        {
            gameObject.transform.forward = move;
            
        }
        
    }
}
