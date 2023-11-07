 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] protected GameObject[] wayPoints;
    protected int currentWayPoint = 0;
    protected float speed = 2f;
    
    void Update()
    {
        if(Vector2.Distance(transform.position, wayPoints[currentWayPoint].transform.position) < 0.5f)
        {
            currentWayPoint++;
            if(currentWayPoint >= wayPoints.Length)
            {
                currentWayPoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
    }
}
