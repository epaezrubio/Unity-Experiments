using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    public ObstaclePad bottom;

    [SerializeField]
    public ObstaclePad left;

    [SerializeField]
    public ObstaclePad right;

    [SerializeField]
    private ObstacleScriptable obstacleConfig;

    void Start()
    {
        if (obstacleConfig)
        {
            ConfigureObstaclePad(bottom, obstacleConfig.bottom);
            ConfigureObstaclePad(left, obstacleConfig.left);
            ConfigureObstaclePad(right, obstacleConfig.right);
        }
    }

    private void ConfigureObstaclePad(ObstaclePad pad, obstableColor color)
    {
        if (color == obstableColor.blue)
        {
            pad.blue.SetActive(true);
        }
        else if (color == obstableColor.orange)
        {
            pad.orange.SetActive(true);
        }
        else if (color == obstableColor.black)
        {
            pad.black.SetActive(true);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawMesh(GetGizmoMesh(), transform.position - new Vector3(0.5f, 0.5f, 0));
    }

    private Mesh GetGizmoMesh()
    {

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        mesh.uv = uv;

        return mesh;
    }
}
