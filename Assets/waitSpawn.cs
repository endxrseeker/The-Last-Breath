using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitSpawn : MonoBehaviour
{
    public BoxCollider collider;
    public CapsuleCollider cap;
    public void Start()
    {
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(4f);

        cap.enabled = true;
        collider.enabled = true;
    }
}
