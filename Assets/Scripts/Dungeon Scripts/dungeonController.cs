using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonController : MonoBehaviour
{
    public GameObject[] rooms;
    public int maxRoomNumber = 20;
    public int maxDungeonSize = 250;
    private int maxLevels = 1;

    public GameObject roomParent;

    public List<GameObject> roomsList;

    public void Start()
    {
        int levelBeingGenerated = 0;
        for (int i = 0; i < maxLevels; i++)
        {
            int yLevel;
            yLevel = levelBeingGenerated * 20;

            for (int j = 0; j < maxRoomNumber; j++)
            {
                int randomRoom = Random.Range(0, rooms.Length);

                int RandomX = Random.Range(-maxDungeonSize, maxDungeonSize);
                int RandomZ = Random.Range(-maxDungeonSize, maxDungeonSize);

                RandomZ = RandomZ / 10;
                Mathf.Round(RandomZ);
                RandomZ = RandomZ * 10;

                RandomX = RandomX / 10;
                Mathf.Round(RandomX);
                RandomX = RandomX * 10;

                GameObject room = Instantiate(rooms[randomRoom], new Vector3(RandomX, yLevel, RandomZ), Quaternion.identity);

                Collider[] col = Physics.OverlapBox(room.transform.position, new Vector3(20, 3, 20), room.transform.rotation);
                if (col.Length > 1)
                {
                    Destroy(room);
                }
                roomsList.Add(room);
            }
            levelBeingGenerated++;
        }

        searchNeighbours();
    }

    void searchNeighbours()
    {
        foreach (GameObject room in roomsList)
        {
            roomController controller = room.GetComponent<roomController>();

            controller.getNeighbours();
        }
    }
}
