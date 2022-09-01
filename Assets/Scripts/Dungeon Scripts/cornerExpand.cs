using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerExpand : MonoBehaviour
{
    [HideInInspector]
    public int expandingIterations;

    public GameObject hall;

    GameObject front;
    GameObject back;
    GameObject right;
    GameObject left;

    public void Start()
    {
        front = transform.GetChild(0).gameObject;
        back = transform.GetChild(1).gameObject;
        right = transform.GetChild(2).gameObject;
        left = transform.GetChild(3).gameObject;

        expand();
    }

    public void expand()
    {
        GameObject Front = Instantiate(hall, new Vector3(front.transform.position.x, front.transform.position.y, front.transform.position.z), front.transform.rotation, gameObject.transform);
        hallExtender hallExtender = Front.GetComponent<hallExtender>();
        hallExtender.cornerExpand = gameObject.GetComponent<cornerExpand>();

        GameObject Back = Instantiate(hall, new Vector3(back.transform.position.x, back.transform.position.y, back.transform.position.z), back.transform.rotation, gameObject.transform);
        hallExtender hallExtender1 = Back.GetComponent<hallExtender>();
        hallExtender1.cornerExpand = this.gameObject.GetComponent<cornerExpand>();

        GameObject Right = Instantiate(hall, new Vector3(right.transform.position.x, right.transform.position.y, right.transform.position.z), right.transform.rotation, gameObject.transform);
        hallExtender hallExtender2 = Right.GetComponent<hallExtender>();
        hallExtender2.cornerExpand = this.gameObject.GetComponent<cornerExpand>();

        GameObject Left = Instantiate(hall, new Vector3(left.transform.position.x, left.transform.position.y, left.transform.position.z), left.transform.rotation, gameObject.transform);
        hallExtender hallExtender3 = Left.GetComponent<hallExtender>();
        hallExtender3.cornerExpand = this.gameObject.GetComponent<cornerExpand>();

        expandingIterations = 1;
    }
}
