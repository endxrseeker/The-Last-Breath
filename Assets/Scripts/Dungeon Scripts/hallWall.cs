using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallWall : MonoBehaviour
{
    public GameObject rightWall;
    public GameObject leftWall;
    public GameObject backWall;

    public void Update()
    {
        float time = 0;
        bool done = false;
        time += Time.deltaTime;

        if(time > 4 && !done)
        {
            if(Physics.Raycast(new Vector3(rightWall.transform.position.x + 5, rightWall.transform.position.y, rightWall.transform.position.z), Vector3.down))
            {
                rightWall.SetActive(true);
            }
            else rightWall.SetActive(false);

            if (Physics.Raycast(new Vector3(leftWall.transform.position.x - 5, leftWall.transform.position.y, leftWall.transform.position.z), Vector3.down))
            {
                leftWall.SetActive(true);
            }
            else leftWall.SetActive(false);

            if (Physics.Raycast(new Vector3(backWall.transform.position.x, backWall.transform.position.y, backWall.transform.position.z - 5), Vector3.down))
            {
                backWall.SetActive(true);
            }
            else backWall.SetActive(false);
        }
    }
}
