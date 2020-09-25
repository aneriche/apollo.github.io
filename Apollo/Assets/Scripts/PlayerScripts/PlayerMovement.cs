using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private CharacterController controller;

    public float playerSpeed = 2.0f;
    private float gravity = -9.81f;
    //private float jumpHeight = 1.0f;

    // Get the joystick gameobject
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0.0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) 
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        /*if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }*/

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
