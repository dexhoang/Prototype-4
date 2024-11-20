using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    public int lineSegments = 50;
    public Material coneMaterial;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = lineSegments + 1;
        lineRenderer.material = coneMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        DrawFOV();
    }

    void DrawFOV()
    {
        float angleStep = viewAngle / lineSegments;
        lineRenderer.SetPosition(0, transform.position);

        for (int i = 0; i <= lineSegments; i++)
        {
            float angle = -viewAngle / 2 + angleStep * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            Vector3 endPoint = transform.position + direction * viewRadius;
            lineRenderer.SetPosition(i + 1, endPoint);
        }
    }
}
