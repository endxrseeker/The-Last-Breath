using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    AIStates state;

    public GameObject Eyes;

    Vector3 lastKnownPos;
    bool canSee;

    public NavMeshAgent agent;
    public GameObject player;
    public GameObject gameOver;

    public enum AIStates
    {
        searching,
        chasing,
        searchingLastSeen
    }

    public void Start()
    {
        state = AIStates.searching;
    }

    public void Update()
    {
        player = GameObject.Find("Player");

        agent.SetDestination(player.transform.position);
        lastKnownPos = player.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            o2Manager manager = other.gameObject.gameObject.GetComponent<o2Manager>();

            manager.currentOxygen = 0;
        }
    }
}
