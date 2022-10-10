using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallWall : MonoBehaviour
{
    public GameObject rightWall;
    public GameObject leftWall;
    public GameObject backWall;
    public GameObject frontWall;
    
    public Transform rightWallpos;
    public Transform leftWallpos;
    public Transform backWallpos;
    public Transform frontWallpos;

    public void Start()
    {
        StartCoroutine(wait());
    }

    void placeWalls()
    {
        print("YYes");
        if (!Physics.Raycast(rightWallpos.position, Vector3.down))
        {
            rightWall.SetActive(true);
        }
        else rightWall.SetActive(false);

        if (!Physics.Raycast(leftWallpos.position, Vector3.down))
        {
            leftWall.SetActive(true);
        }
        else leftWall.SetActive(false);

        if (!Physics.Raycast(backWallpos.position, Vector3.down))
        {
            backWall.SetActive(true);
        }
        else backWall.SetActive(false);

        if (!Physics.Raycast(frontWallpos.position, Vector3.down))
        {
            frontWall.SetActive(true);
        }
        else frontWall.SetActive(false);
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(10f);

        placeWalls();
    }
}
