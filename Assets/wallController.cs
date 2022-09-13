using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallController : MonoBehaviour
{
    public GameObject FrontWall;
    public GameObject BackWall;
    public GameObject LeftWall;
    public GameObject RightWall;

    public Transform frontWall;
    public Transform backWall;
    public Transform leftWall;
    public Transform rightWall;


    private void Update()
    {
        float i = 0;
        if (i < 2)
        {
            i += Time.deltaTime;
        }
        else putWalls();
    }

    void putWalls()
    {
        if (!Physics.Raycast(frontWall.position, Vector3.down))
        {
            FrontWall.SetActive(true);
        }
        else FrontWall.SetActive(false);

        if (!Physics.Raycast(backWall.position, Vector3.down))
        {
            BackWall.SetActive(true);
        }
        else BackWall.SetActive(false);

        if (!Physics.Raycast(leftWall.position, Vector3.down))
        {
            LeftWall.SetActive(true);
        }
        else LeftWall.SetActive(false);

        if (!Physics.Raycast(rightWall.position, Vector3.down))
        {
            RightWall.SetActive(true);
        }
        else RightWall.SetActive(false);
    }
}
