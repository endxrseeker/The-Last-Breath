using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour
{
    List<GameObject> neighbouringRooms;
    public GameObject controller;
    public dungeonController roomSpawner;
    public GameObject cornerPiece;

    float closestRoomDistance = 1000000000000000000;
    float secondClosestRoomDistance = 1000000000000000000;
    float thirdClosestRoomDistance = 1000000000000000000;
    public int maxIterations = 25;

    public GameObject closestRoom;
    public GameObject secondClosestRoom;
    public GameObject thirdClosestRoom;

    Vector3 crossSection;
    Vector3 secondCrossSection;
    Vector3 thirdCrossSection;

    public void getNeighbours()
    {
        controller = GameObject.Find("Dungeon Controller");
        roomSpawner = controller.GetComponent<dungeonController>();

        foreach (GameObject rooms in roomSpawner.roomsList)
        {
            if (rooms != this.gameObject)
            {
                if (Vector3.Distance(transform.position, rooms.transform.position) < closestRoomDistance)
                {
                    closestRoomDistance = Vector3.Distance(transform.position, rooms.transform.position);
                    closestRoom = rooms;
                }
                else if (Vector3.Distance(transform.position, rooms.transform.position) < secondClosestRoomDistance)
                {
                    secondClosestRoomDistance = Vector3.Distance(transform.position, rooms.transform.position);
                    secondClosestRoom = rooms;
                }
                else if (Vector3.Distance(transform.position, rooms.transform.position) < thirdClosestRoomDistance)
                {
                    thirdClosestRoomDistance = Vector3.Distance(transform.position, rooms.transform.position);
                    thirdClosestRoom = rooms;
                }
            }
        }

        makePath();
    }
    public void makePath()
    {
        if (closestRoom != null)
        {
            crossSection = new Vector3(closestRoom.transform.position.x, 0, transform.position.z);
            GameObject corner = Instantiate(cornerPiece, crossSection, Quaternion.identity);
            corner.transform.LookAt(closestRoom.transform);
        }
        if (secondClosestRoom != null)
        {
            secondCrossSection = new Vector3(secondClosestRoom.transform.position.x, 0, transform.position.z);
            GameObject corner = Instantiate(cornerPiece, secondCrossSection, Quaternion.identity);
            corner.transform.LookAt(secondClosestRoom.transform);
        }
        if (thirdClosestRoom != null)
        {
            thirdCrossSection = new Vector3(thirdClosestRoom.transform.position.x, 0, transform.position.z);
            GameObject corner = Instantiate(cornerPiece, thirdCrossSection, Quaternion.identity);
            corner.transform.LookAt(thirdClosestRoom.transform);
        }

        float angle1 = Vector3.Angle(crossSection - closestRoom.transform.position, crossSection - transform.position);
    }
}
