using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController playerController; //refenence to the character controller attached to the player


    // ------------PLAYER MOVEMENT VARIABLES------------
    public float playerWalkSpeed = 2f; //the player's movement speed
    public float playerRunSpeed = 4f; //the player's movement speed
    public float playerSprintSpeed = 8f; //the player's sprint speed
    
    public bool walkOrRun; //is the player walking or running?
    // -------------------------------------------------

    // ------------PLAYER FALL VARIABLES------------
    public float gravity = -9.81f; //the speed that the player falls at

    Vector3 playerVelocity; //the vector for falling movement
    // ---------------------------------------------


    private void Start()
    {
        walkOrRun = true;

        playerVelocity.y = gravity; //set the "playerVelocity" Vector3's Y value to be equal to that of the gravity value
    }


    void Update()
    {  

        float moveX = Input.GetAxis("Horizontal"); //set "moveX" to read from unity's built in "Horizontal" axis (A and D keys)
        float moveZ = Input.GetAxis("Vertical"); //set "moveX" to read from unity's built in "Vertical" axis (W and S keys)

        Vector3 playerMove = transform.right * moveX + transform.forward * moveZ; //honestly I can't remember what this exactly does in a mechanical sense, but in a practical sense it puts both directions of movement input into one variable which makes the below section a lot cleaner.

        if (Input.GetKeyDown(KeyCode.LeftAlt)) //if the player presses the left alt key...
        {
            walkOrRun = !walkOrRun; //set "walkOrRun" to the opposite of what it currently is
        }


        if (Input.GetKey(KeyCode.LeftShift)) //if the left shift key is being pressed...
        {
            playerController.Move(playerMove * playerSprintSpeed * Time.deltaTime); //tell the player controller to move the player according to "playerMove", multiplied by the sprint speed, multiplied by Time.deltaTime
        }
        else //otherwise...
        {
            if (walkOrRun == true) //if "walkOrRun" is set to true...
            {
                playerController.Move(playerMove * playerWalkSpeed * Time.deltaTime); //make the player use walking speed
            }
            else //otherwise...
            {
                playerController.Move(playerMove * playerRunSpeed * Time.deltaTime); //make the player use running speed
            }
        }

        playerController.Move(playerVelocity * Time.deltaTime); //move the player according to the direction of "playerVelocity"
        
    }
}
