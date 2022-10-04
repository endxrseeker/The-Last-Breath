using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTwo : MonoBehaviour
{
    public bool lever_Active = false;
    public GameObject Lever_Handle;

    public GameObject doorway;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 7 && !lever_Active)
        {
            lever_Active = true;
            Debug.Log("Lever Activated");

            Lever_Handle.transform.localPosition = new Vector3(0f, 0.141f, -0.106f);
            Lever_Handle.transform.localRotation = Quaternion.Euler(42, 0, 0);

            doorway.transform.position = new Vector3(doorway.transform.position.x, doorway.transform.position.y + 4f, doorway.transform.position.z);
        }
        else
        {
            lever_Active = false;
            Debug.Log("Lever Deactivated");

            Lever_Handle.transform.localPosition = new Vector3(0f, 0.141f, 0.106f);
            Lever_Handle.transform.localRotation = Quaternion.Euler(-42, 0, 0);

            doorway.transform.position = new Vector3(doorway.transform.position.x, doorway.transform.position.y - 4f, doorway.transform.position.z);
        }

    }


}