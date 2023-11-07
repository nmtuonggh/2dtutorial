using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SawAnm : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected GameObject[] wayPoints;
    protected int currentWayPoint = 0;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 360 * speed/2 * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[currentWayPoint].transform.position) < 0.5f)
        {
            currentWayPoint++;
            if (currentWayPoint >= wayPoints.Length)
            {
                currentWayPoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            wayPoints[currentWayPoint].transform.position, speed * Time.deltaTime);
    }

    
}
