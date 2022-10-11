using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygenManager : MonoBehaviour
{
    // ------------PLAYER BASIC BREATHING VARIABLES------------
    public int maximumPlayerOxygen = 100; //what is the maximum oxygen value the player can have?
    public float currentPlayerOxygen; //this is the counter for the player's oxygen. This value will be constantly fluctuating during gameplay

    public float playerOxygenDrainRate = 1; //how quickly will the player consume oxygen? NOTE: Higher numbers result in a slower drain rate

    bool playerIsSprinting = false; //is the player sprinting? Used to increase the oxygen drain rate
    // --------------------------------------------------------


    // ------------OXYGEN CANISTER VARIABLES------------
    public float canisterRecoveryRate = 2; //how many units of oxygen per second should the player gain from oxygen canisters

    float bankedOxygen = 0; //used for breathing from o2 canisters

    public int currentAmountOfCanistersInHand = 0; //this is the variable for keeping track of how many canisters the player currently is holding in their hands

    GameObject canisterInHandOne; //the oxygen canister occupying the first canister slot
    GameObject canisterInHandTwo; //the oxygen canister occupying the second canister slot
    public GameObject hand;
    public GameObject gameOver;

    GameObject activeCanister; //the oxygen canister currently being consumed

    //-------------------------------------------------------------------------------
    Vector3 canisterOneStartLocation = new Vector3(0.353f, 1.286f, 0.17f);            // |||| ----> These are the location and rotation vectors that are assigned to the first canister the player picks up
    Quaternion canisterOneRotation = Quaternion.Euler(-71.5f, 360.1f, -255.2f); //  ||/

    Vector3 canisterTwoStartLocation = new Vector3(0.167f, 1.252f, 0.222f);         // |||| ----> These are the location and rotation vectors that are assigned to the second canister the player picks up
    Quaternion canisterTwoRotation = Quaternion.Euler(-69.6f, -15.7f, 97.3f); //  ||/
    //-------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------
    Vector3 canisterOneEndLocation = new Vector3(0.353f, 1.336f, 0.17f);  // |||| 
                                                                                     // |||| ----> These are the locations for each canister when they are selected by the player
    Vector3 canisterTwoEndLocation = new Vector3(0.147f, 1.322f, 0.222f); // ||||
    //-------------------------------------------------------------------------------


    void Start()
    {
        currentPlayerOxygen = maximumPlayerOxygen; //when the game begins, always set the player's current oxygen to the maximum value

        StartCoroutine(playerOxygenDrain()); //begin the "playerOxygenDrain' coroutine to start counting down the player's oxygen
    }


    private void Update()
    {

        if (Input.mouseScrollDelta.y != 0 && currentAmountOfCanistersInHand == 2) //if the player moves the mouse scroll wheel &AND& they are currently carrying two oxygen canisters...
        {
            SelectCanisterToUse(); //call the "SelectCanisterToUse" function to change the currently selected canister
        }

        if (Input.GetKey(KeyCode.Mouse1) && activeCanister.gameObject.GetComponent<OxygenCanister>().currentOxygenInCanister > 0 && currentPlayerOxygen < maximumPlayerOxygen - 2) //if the player presses the right mouse button &AND& the active canister still has oxygen remaining &AND& the player currently has at least two less than the maximum allowed oxygen...
        {
            BreatheFromCanister(); //call the "BreatheFromCanister" function to begin breathing from the currently selected canister
        }

        if (Input.GetKeyDown(KeyCode.Mouse2)) //if the player presses the middle mouse button...
        {
            StartCoroutine(DropSelectedCanister()); //call the "DropSelectedCanister" function to drop the currently selected canister
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) //DEBUG TOOL DEBUG TOOL DEBUG TOOL \ if the player presses the right mouse button... \ DEBUG TOOL DEBUG TOOL DEBUG TOOL
        {
            currentPlayerOxygen -= 10; //DEBUG TOOL DEBUG TOOL DEBUG TOOL \ decriment "currentPlayerOxygen" by 10... \ DEBUG TOOL DEBUG TOOL DEBUG TOOL
        }

    }


    private IEnumerator playerOxygenDrain()
    {
        while (currentPlayerOxygen > 0) //while "currentPlayerOxygen" is greater than 0 (the player has not yet run out of oxygen)...
        {
            if (playerIsSprinting) //if the player is currently sprinting...
            {
                currentPlayerOxygen -= playerOxygenDrainRate * 2; //decriment the value of "currentPlayerOxygen" by "playerOxygenDrainRate" mupltiplied by 2
            }
            else //otherwise...
            {
                currentPlayerOxygen -= playerOxygenDrainRate; //decriment the value of "currentPlayerOxygen" by "playerOxygenDrainRate"
            }

            //Debug.Log(currentPlayerOxygen); //print the value of "currentPlayerOxygen" to the console

            yield return new WaitForSeconds(1); //pause this coroutine for a number of seconds equal to "playerOxygenDrainRate"

            yield return null; //repeat this while loop
        }

        //this is where the code that kills the player and ends the game would go
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }


    public void BreatheFromCanister()
    {
        bankedOxygen += (1 + canisterRecoveryRate) * Time.deltaTime; //incriment "bankedOxygen" by 1 + "canisterRecoveryRate", and multiply the result by Time.deltaTime

        activeCanister.gameObject.GetComponent<OxygenCanister>().currentOxygenInCanister -= (canisterRecoveryRate) * Time.deltaTime; //decriment "currentOxygenInCanister" from the active canister's "OxygenCanister" script by 1 + "canisterRecoveryRate", and multiply the result by Time.deltaTime

        if (bankedOxygen >= 2) // if "bankedOxygen" is greater than or equal to 2...
        {
            currentPlayerOxygen += 2; //incriment "currentPlayerOxygen" by 2

            bankedOxygen = 0; //set "bankedOxygen" back down to 0
        }
    }


    public void OxygenCanisterPickedUp(GameObject pickedUpCanister)
    {
        pickedUpCanister.transform.parent = hand.transform; //set the newly picked up canister's parent to be this game object (the player)

        if (currentAmountOfCanistersInHand == 0 || currentAmountOfCanistersInHand == 1 && canisterInHandOne == null) //if the player does not have any oxygen canisters |OR| the player has one oxygen canister &AND& it's not in slot one...
        {
            canisterInHandOne = pickedUpCanister; //assign the canister than was just collected to the "canisterInHandOne" variable

            activeCanister = canisterInHandOne; //set the active canister to the first canister

            pickedUpCanister.transform.position = hand.transform.position;
            pickedUpCanister.transform.rotation = hand.transform.rotation;
        }
        else if (currentAmountOfCanistersInHand == 1) //otherwise if "currentCanistersInHand" is equal to 1... (the player has only 1 canister)
        {
            canisterInHandTwo = pickedUpCanister; //assign the canister than was just collected to the "canisterInHandTwo" variable

            canisterInHandTwo.transform.localPosition = canisterTwoStartLocation; //set the second canister's location to the designated location for the second canister
            canisterInHandTwo.transform.localRotation = canisterTwoRotation; //set the second canister's rotation to the designated rotation for the second canister

            activeCanister.transform.localPosition = new Vector3(activeCanister.transform.localPosition.x, activeCanister.transform.localPosition.y + 0.05f, activeCanister.transform.localPosition.z);
        }
        /* there is no need to check if "currentCanistersInHand" is equal to 2 (two canisters in hand) as if that was the case the player would have no more space and so
         * they would not pick up the canister and nothing would happen, the same as if there simply was not a check if "currentCanistersInHand" equalled 2 in the first place
         */

        currentAmountOfCanistersInHand++; //incriment the current amount of canisters in hand by 1
    }


    public void SelectCanisterToUse()
    {
        if (activeCanister == canisterInHandOne) //if the player scrolls the mouse up &AND& the active canister is the first canister...
        {
            activeCanister.transform.localPosition = canisterOneStartLocation;

            activeCanister = canisterInHandTwo; //switch the active canister to the first canister

            activeCanister.transform.localPosition = canisterTwoEndLocation;

            /*while (activeCanister.transform.localPosition != canisterTwoLerpLocationEnd)
            {
                float elapsedTime = 0f;

                canisterInHandOne.transform.localPosition = Vector3.Lerp(canisterOneLocationEnd, canisterOneLocation, elapsedTime;

                canisterInHandTwo.transform.localPosition = Vector3.Lerp(canisterTwoLocation, canisterTwoLocationEnd, elapsedTime);

                elapsedTime += Time.deltaTime

                yield return null;
            }
            activeCanister = canisterInHandTwo; //switch the active canister to the second canister*/
        }
        else //otherwise if the player scrolls the mouse down &AND& the active canister is the second canister...
        {
            activeCanister.transform.localPosition = canisterTwoStartLocation;

            activeCanister = canisterInHandOne; //switch the active canister to the first canister

            activeCanister.transform.localPosition = canisterOneEndLocation;

            /*while (activeCanister.transform.localPosition != canisterOneLerpLocationEnd)
            {
                float elapsedTime = 0f;

                canisterInHandTwo.transform.localPosition = Vector3.Lerp(canisterTwoLocationEnd, canisterTwoLocation, Time.deltaTime);

                canisterInHandOne.transform.localPosition = Vector3.Lerp(canisterOneLocation, canisterOneLocationEnd, Time.deltaTime);
                
                elapsedTime += Time.deltaTime

                yield return null;
            }
            activeCanister = canisterInHandOne; //switch the active canister to the first canister*/
        }

        //yield return null;
    }


    public IEnumerator DropSelectedCanister()
    {
        GameObject droppedCanister; //create a new GameObject for this function called "droppedCanister"

        activeCanister.transform.parent = null; //remove the parent from the active canister (this will cause it to fall to the ground)

        droppedCanister = activeCanister; //set "droppedCanister" variable to the the same as "activeCanister"

        droppedCanister.GetComponent<Rigidbody>().useGravity = true; //enable gravity on "droppedCanister"'s rigidbody
        droppedCanister.GetComponent<CapsuleCollider>().enabled = true; //enable the first box collider of "droppedCanister"

        if (activeCanister == canisterInHandOne) //if the active canister is currently the first one...
        {
            canisterInHandOne = null; //clear the "canisterInHandOne" variable
            activeCanister = canisterInHandTwo; //set "activeCanister" to the second (and only) canister

        }
        else //otherwise...
        {
            canisterInHandTwo = null; //clear the "canisterInHandTwo" variable
            activeCanister = canisterInHandOne; //set "activeCanister" to the first (and only) canister
        }

        currentAmountOfCanistersInHand--; //decriment the current amount of canisters in hand by 1

        yield return new WaitForSeconds(3); //wait for three second

        droppedCanister.GetComponent<BoxCollider>().enabled = true; //enable the second box collider of "droppedCanister"

        yield return null; //end the coroutine
    }
}
