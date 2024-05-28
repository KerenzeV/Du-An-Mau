using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public float FollowSpeed = 2f;
    public float yOFFset = 1f;
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        Vector3 newFos = new Vector3(target.position.x, target.position.y + yOFFset, -10f);
        transform.position = Vector3.Slerp(transform.position, newFos, FollowSpeed);

    }
}