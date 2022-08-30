using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    bool lever_Active = false;
    public float timer;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            lever_Active = true;
            Debug.Log("Lever Active");
        }
    }
}
