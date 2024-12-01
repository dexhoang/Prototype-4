using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class VisionCone : MonoBehaviour
{
    public float visionRange = 10f;
    public float visionAngle = 45f;
    public int segments = 10;
    private Mesh visionMesh;

    private void Start()
    {
        visionMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = visionMesh;
    }

    private void Update()
    {
        //DrawVisionCone();
    }

    //private void DrawVisionCone()
    //{
    //    Vector3[] vertices = new Vector3[segments + 2];
    //    int[] triangles = new int[segments * 3];

    //    // Cone origin
    //    vertices[0] = Vector3.zero;

    //    // Generate cone edge points
    //    float angleStep = (visionAngle * 2) / segments;
    //    for (int i = 0; i <= segments; i++)
    //    {
    //        float angle = -visionAngle + angleStep * i;
    //        float radian = Mathf.Deg2Rad * angle;

    //        float x = Mathf.Sin(radian) * visionRange;
    //        float z = Mathf.Cos(radian) * visionRange;

    //        vertices[i + 1] = new Vector3(x, 0, z);
    //    }

    //    // Create triangles
    //    for (int i = 0; i < segments; i++)
    //    {
    //        triangles[i * 3] = 0;
    //        triangles[i * 3 + 1] = i + 1;
    //        triangles[i * 3 + 2] = i + 2;
    //    }

    //    // Assign data to the mesh
    //    visionMesh.Clear();
    //    visionMesh.vertices = vertices;
    //    visionMesh.triangles = triangles;
    //    visionMesh.RecalculateNormals();
    //}
}
