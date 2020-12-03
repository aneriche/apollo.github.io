using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private CharacterController controller;
    public float playerSpeed = 1.0f;
    public Joystick joystick;
    private bool hasParent;
    private Vector3 lastParentPosition;
    public GameObject Player;

    private bool doRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (GameStatus.inMenu == 1) {
            controller.enabled = false;
            Player.transform.position = new Vector3(GameStatus.playerPositionInMenuX,GameStatus.playerPositionInMenuY,GameStatus.playerPositionInMenuZ);
            controller.enabled = true;
        }
    }

    void applyRotation() {
        Player.transform.Rotate(Player.transform.right, -20f);
    }

    void still() {
        Player.transform.Rotate(Player.transform.right, 20f);
    }

    void FixedUpdate() {
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(joystick.Horizontal + Input.GetAxis("Horizontal"), 0, joystick.Vertical + Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * playerSpeed);

        transform.rotation = Quaternion.LookRotation(move);
        
    }
}
