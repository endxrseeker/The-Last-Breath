using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCanister : MonoBehaviour
{
    // ------------REFERENCE VARIABLES------------
    public CapsuleCollider collisionCollider; //the collider that is used for collision
    public BoxCollider triggerCollider; //the collider that is used for detecting when the player gets close enough
    public Rigidbody rigidBody; //the rigidbody used for enabling gravity on the canister

    public GameObject dial; //the dial that indicates to the player how much oxygen is left in the canister

    public PlayerOxygenManager playerOxygenManager; //a reference to the "PlayerOxygenManager" script

    // -------------------------------------------------


    // ------------OXYGEN VARIABLES------------
    public int totalOxygenInCanister = 50; //the total amount of oxygen a canister can restore
    public float currentOxygenInCanister; //the current amount of oxygen stored in a canister. This number can only go down during gameplay
    // ----------------------------------------

    void Start()
    {
        currentOxygenInCanister = totalOxygenInCanister; //when the game begins, always set the canister's current oxygen to the maximum value

        dial.transform.localRotation = Quaternion.Euler(-80, 0, 0);
    }


    private void Update()
    {
        dial.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(-80, 0, 0), Quaternion.Euler(80, 0, 0), currentOxygenInCanister/totalOxygenInCanister);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7) //if the object that enters the trigger is on layer 7 (the Player layer) &AND& the player is not already carrying two canisters...
        {
            playerOxygenManager = other.gameObject.GetComponent<PlayerOxygenManager>();

            if (playerOxygenManager.currentAmountOfCanistersInHand != 2)
            {
                playerOxygenManager.OxygenCanisterPickedUp(gameObject); //call the "OxygenCanisterPickedUp" function from the "playerOxygenManager" script and tell the function which object this is

                collisionCollider.enabled = false; //disable the collsion collider of this object
                triggerCollider.enabled = false; //disable the trigger collider of this object
                                                 //rigidBody.useGravity = false; //disable the gravity component of the rigidbody on this object
            }
        }
        
    }
}
