using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowWaypointsAI : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWP = 0;
    float minRemainingDistance = 1f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
          GoToNextPoint();
        }
    }

    void GoToNextPoint() {
        if(waypoints.Length == 0)
        {
            enabled = false;
            return;
        }
        agent.destination = waypoints[currentWP].position;
        currentWP = (currentWP + 1) % waypoints.Length;
    }
}
