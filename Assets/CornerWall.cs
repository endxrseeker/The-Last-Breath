using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerWall : MonoBehaviour
{
    public GameObject FrontWall;
    public GameObject BackWall;
    public GameObject LeftWall;
    public GameObject RightWall;

    private void Update()
    {
        PlaceWalls();
    }

    public void PlaceWalls()
    {
        print("I wanna not");
        if (Physics.Raycast(new Vector3(FrontWall.transform.position.x, 5, FrontWall.transform.position.z + 5), Vector3.down))
        {
            FrontWall.gameObject.SetActive(false);
        }
        else FrontWall.gameObject.SetActive(true);

        if (Physics.Raycast(new Vector3(BackWall.transform.position.x, 5, BackWall.transform.position.z - 5), Vector3.down))
        {
            BackWall.gameObject.SetActive(false);
        }
        else BackWall.gameObject.SetActive(true);

        if (Physics.Raycast(new Vector3(LeftWall.transform.position.x - 5, 5, LeftWall.transform.position.z), Vector3.down))
        {
            LeftWall.gameObject.SetActive(false);
        }
        else LeftWall.gameObject.SetActive(true);

        if (Physics.Raycast(new Vector3(RightWall.transform.position.x + 5, 5, RightWall.transform.position.z), Vector3.down))
        {
            RightWall.gameObject.SetActive(false);
        }
        else RightWall.gameObject.SetActive(true);
    }
}
