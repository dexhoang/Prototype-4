using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVision : MonoBehaviour
{
    public Transform player;
    public GameObject Player;
    public float visionRange = 10f;
    public float visionAngle = 45f;
    private Vector3 originalPos;


    private void Start()
    {
        originalPos = new Vector3(-0.16f, 3.05f, 28.95f);
    }

    void Update()
    {
        // Calculate direction to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Check if the player is within the vision range
        if (directionToPlayer.magnitude <= visionRange)
        {
            // Check if the player is within the vision angle
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= visionAngle)
            {
                Player.transform.position = originalPos;
                Debug.Log($"{gameObject.name} sees the player! Player is teleported back!");
            }
        }
    }

    // draws vision cone
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 forward = transform.forward * visionRange;

        Quaternion leftRayRotation = Quaternion.Euler(0, -visionAngle, 0);
        Quaternion rightRayRotation = Quaternion.Euler(0, visionAngle, 0);

        Vector3 leftRayDirection = leftRayRotation * forward;
        Vector3 rightRayDirection = rightRayRotation * forward;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftRayDirection);
        Gizmos.DrawRay(transform.position, rightRayDirection);
    }
}

