using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o2 : MonoBehaviour
{
    GameObject player;
    o2Manager manager;

    public GameObject body;
    public SphereCollider coll;

    public void Update()
    {
        player = GameObject.Find("Player");
        manager = player.GetComponent<o2Manager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            manager.o2PickUp();
            body.SetActive(false);
            coll.enabled = false;

            StartCoroutine(respawnTime());
        }
    }

    IEnumerator respawnTime()
    {
        yield return new WaitForSeconds(120f);
        body.SetActive(true);
        coll.enabled = true;
    }
}
