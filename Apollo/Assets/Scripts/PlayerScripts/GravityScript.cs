using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public Transform player;
    public float gravity;
    private CharacterController controller;
    public Transform respawnPoint;
    public Transform deathPlane;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * Time.deltaTime * gravity);
        }
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y < deathPlane.transform.position.y)
        {
            Debug.Log(player.transform.position);
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
