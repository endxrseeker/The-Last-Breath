using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float verticalMouseSensitivity = 100f; //used to change the speed the camera moves up and down

    public float horizontalMouseSensitivity = 100f; //used to change the speed the camera moves side to side

    public Transform playerBody; //used to rotate the player's body from side to side

    public Transform playerCamera; //used to rotate the player's camera up and down

    float playerXRotation = 0f; //used to determine how much the player should be rotated side to side by


    private void Start()
    {
        GameplayBegin();
    }


    void GameplayBegin()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor to the center of the screen
    }


    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * horizontalMouseSensitivity * Time.deltaTime; //set "mouseX" equal to unity's built in "Mouse X" axis (horizontal mouse movement), multiplied by "horizontalMouseSensitivity", multiplied by "Time.deltaTime" (the time since the last frame)
        //float mouseY = Input.GetAxis("Mouse Y") * verticalMouseSensitivity * Time.deltaTime; //set "mouseY" equal to unity's built in "Mouse Y" axis (vertical mouse movement), multiplied by "verticalMouseSensitivity", multiplied by "Time.deltaTime" (the time since the last frame)

        //playerXRotation -= mouseY; //set "playerXRotation" equal to itself minus "mouseY"
        //playerXRotation = Mathf.Clamp(playerXRotation, -60f, 60); //clamp "playerXRotation" to values between -60 and 60

        //playerCamera.localRotation =  Quaternion.Euler(playerXRotation, 0f, 0f); //set the local rotation of "playerCamera" equal to "playerXRotation"
        //playerBody.Rotate(Vector3.up, mouseX); //rotate "playerBody" on the vertical axis by "mouseX" amount

        playerXRotation += -Input.GetAxis("Mouse Y") * 2;
        playerXRotation = Mathf.Clamp(playerXRotation, -80, 80);
        playerCamera.transform.localRotation = Quaternion.Euler(playerXRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * 2, 0);
    }
}
