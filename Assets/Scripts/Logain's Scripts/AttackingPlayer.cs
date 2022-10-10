using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPlayer : MonoBehaviour
{

    public bool Dead;
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        Dead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Dead = true;
        GameManager.Dead = true;    //This Line is all that matters, could rearrange everything and fit it within the Actual AI Script
    }

}
