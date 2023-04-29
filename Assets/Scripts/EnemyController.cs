using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;

    private float distanceThreshold = 0.1f;
    private int currentIndex = 0;
    private GameObject waypoints;

    private void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints");
    }


    private void FixedUpdate()
    {
        if (currentIndex < waypoints.transform.childCount)
        {
            Vector2 targetWaypoint = waypoints.transform.GetChild(currentIndex).position;

            if(Vector2.Distance(transform.position, targetWaypoint) < distanceThreshold)
            {
                currentIndex++;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            }
        }
    }
}
