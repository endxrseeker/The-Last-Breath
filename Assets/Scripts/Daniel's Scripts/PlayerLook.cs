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

    public bool isAlive = true;


    private void Start()
    {
        isAlive = true;
    }


    void Update()
    {
        if (isAlive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerXRotation += -Input.GetAxis("Mouse Y") * 2;
            playerXRotation = Mathf.Clamp(playerXRotation, -80, 80);
            playerCamera.transform.localRotation = Quaternion.Euler(playerXRotation, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * 2, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
