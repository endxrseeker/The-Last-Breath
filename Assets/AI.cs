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

        Eyes.transform.LookAt(player.transform);
        RaycastHit hit;
        if(Physics.Raycast(Eyes.transform.position, Eyes.transform.forward, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                canSee = true;
                state = AIStates.chasing;
            }
        }
        else canSee = false;

        

        if (state == AIStates.chasing)
        {
            if (!canSee)
            {
                state = AIStates.searchingLastSeen;
            }
        }

        if (lastKnownPos == Vector3.zero && state != AIStates.chasing)
        {
            state = AIStates.searching;
        }

        #region Chasing

        if(state == AIStates.chasing)
        {
            agent.SetDestination(hit.collider.transform.position);
            lastKnownPos = hit.collider.transform.position;
        }

        if(state == AIStates.searchingLastSeen)
        {
            agent.SetDestination(lastKnownPos);

            if(agent.transform.position == lastKnownPos)
            {
                lastKnownPos = Vector3.zero;
                state = AIStates.searching;
            }
        }

        if(state == AIStates.searching)
        {
            //searching
        }

        #endregion
    }
}
