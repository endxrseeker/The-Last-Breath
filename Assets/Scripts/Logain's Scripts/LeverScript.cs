using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    private bool lever_Active = false;
    public Material deactive;
    public Material active;
    public GameObject Lever_Handle;

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (lever_Active == false)
                {
                    lever_Active = true;
                    Debug.Log("Lever Activated");
                    Lever_Handle.GetComponent<Renderer>().material = active;

                }
                else
                {
                    lever_Active = false;
                    Debug.Log("Lever Deactivated");
                    Lever_Handle.GetComponent<Renderer>().material = deactive;
                }

            }
        }
    }

   
}
