using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController controller;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;

    bool isGrounded;

    //Sneak
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;
    private bool sneaking;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);





        //Sneaking on/off

        if (Input.GetKeyDown(KeyCode.LeftControl) && sneaking == false)
        {  
                StartSneak();
                sneaking = true;
                Debug.Log("StartSneak");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && sneaking == true)
        {
                StopSneak();
                sneaking = false;
                Debug.Log("StopSneak");
        }
        
    }


    private void StartSneak()
    {
        
            transform.localScale = crouchScale;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

    }

    private void StopSneak()
    {
       
        
            transform.localScale = playerScale;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        
    }
}

