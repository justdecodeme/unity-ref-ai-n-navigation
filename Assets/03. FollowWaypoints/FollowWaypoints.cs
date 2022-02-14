using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10f;
    public float rotSpeed = 5f;
    public float accuracy = 1f;

    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < accuracy)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        /* sudden rotation */
        //this.transform.LookAt(waypoints[currentWP].transform);

        /* smooth rotation */
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
