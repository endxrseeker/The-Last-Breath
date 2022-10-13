using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 12f;
    public float sprintSpeed = 24f;
    public CharacterController controller;
    //public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;


    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);


        //Sprinting

        if (Input.GetKey(KeyCode.LeftShift))

        {
            walkSpeed = sprintSpeed;
        }
        else

        {
            walkSpeed = 12f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 12f;
        }
    }
}

