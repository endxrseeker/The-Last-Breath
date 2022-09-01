using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    bool lever_Active = false;
    public Material deactive;
    public Material active;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
        Debug.Log("Lever ");

            if (lever_Active == false)
            {
                lever_Active = true;
                Debug.Log("Lever Activated");
                GetComponent<Renderer>().material = active;

            }
            

            else
            {
                lever_Active = false;
                Debug.Log("Lever Deactivated");
                GetComponent<Renderer>().material = deactive;
            }

        }
    }

   
}
