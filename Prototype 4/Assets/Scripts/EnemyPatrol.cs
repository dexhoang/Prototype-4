using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    private bool movingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
        RotateTowardsTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            UpdateTargetPoint();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void UpdateTargetPoint()
    {
        if (movingForward)
        {
            targetPoint++;
            if (targetPoint >= patrolPoints.Length)
            {
                targetPoint = patrolPoints.Length - 2; // Move back to the second last point
                movingForward = false;
            }
        }
        else
        {
            targetPoint--;
            if (targetPoint < 0)
            {
                targetPoint = 1; // Move forward to the second point
                movingForward = true;
            }
        }
        RotateTowardsTarget(); // Rotate to face the next target
    }

    void RotateTowardsTarget()
    {
        // Calculate direction to the target point
        Vector3 directionToTarget = (patrolPoints[targetPoint].position - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = targetRotation;
        }
    }
}
