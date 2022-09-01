using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallExtender : MonoBehaviour
{
    public cornerExpand cornerExpand;
    public roomController roomController;

    GameObject front;
    GameObject back;
    GameObject right;
    GameObject left;

    BoxCollider boxCollider;

    private void Start()
    {
        front = transform.GetChild(1).gameObject;

        boxCollider = GetComponent<BoxCollider>();

        if (cornerExpand.expandingIterations <= roomController.maxIterations)
        {
            print("Doing the funny");
            RaycastHit hit;
            if (!Physics.Raycast(new Vector3(front.transform.position.x, front.transform.position.y + 1, front.transform.position.z), Vector3.down, out hit))
            {
                GameObject Front = Instantiate(cornerExpand.hall, front.transform.position, front.transform.rotation);
                hallExtender hallExtender = Front.GetComponent<hallExtender>();
                hallExtender.cornerExpand = cornerExpand;

                //wallController wallController = Front.GetComponent<wallController>();
                //wallController.putWalls();
            }
            else print(hit.collider.name);
            cornerExpand.expandingIterations++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector3(front.transform.position.x, front.transform.position.y + 1, front.transform.position.z), 2);
    }
}
