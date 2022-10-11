//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class navigationBaker : MonoBehaviour
//{

//    private NavMeshSurface[] surfaces;
//    public List<NavMeshSurface> Surfaces;
//    private Transform[] objectsToRotate;

//    public GameObject[] walk;

//    bool done = false;

//    int count = 0;

//    public void Update()
//    {
//        if (!done)
//        {
//            walk = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];

//            foreach (GameObject go in walk)
//            {
//                if (go.GetComponent<NavMeshSurface>() != null)
//                {
//                    NavMeshSurface goNMS = go.GetComponent<NavMeshSurface>();
//                    Surfaces.Add(goNMS);
//                }
//            }

//            for (int i = 0; i < Surfaces.Count; i++)
//            {
//                Surfaces[i].BuildNavMesh();
//            }

//            count++;

//            if(count >= 10000)
//            {
//                done = true;
//            }
//        }
   
//    }

//}