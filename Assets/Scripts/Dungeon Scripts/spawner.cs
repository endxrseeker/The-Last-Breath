using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject PlayerPref;
    public GameObject monsterPref;

    public int tileSize;

    bool playerInGame = false;
    bool monsterInGame = false;

    public void Update()
    {
        if (playerInGame == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(Random.Range(-tileSize, tileSize), 100, Random.Range(-tileSize, tileSize)), Vector3.down, out hit))
            {
                print("yes");
                Instantiate(PlayerPref, hit.transform.position, Quaternion.identity);
                playerInGame = true;
            }
        }

        if(monsterInGame == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(Random.Range(-tileSize, tileSize), 100, Random.Range(-tileSize, tileSize)), Vector3.down, out hit))
            {
                print("yes");
                Instantiate(monsterPref, hit.transform.position, Quaternion.identity);
                monsterInGame = true;
            }
        }
    }
}