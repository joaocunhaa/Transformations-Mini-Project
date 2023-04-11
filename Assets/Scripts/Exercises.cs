using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExerciseTransformation
{
    None,
    ReflectionY,
    ReflectionX
}

public class Exercises : Transformations
{
    private Mesh mesh;
    private Vector3[] vertices;

    // Vertices
    static private Coordinate p1 = new Coordinate(0, 0);
    static private Coordinate p2 = new Coordinate(10, 0);
    static private Coordinate p3 = new Coordinate(0, 10);
    static private Coordinate p4 = new Coordinate(10, 10);

    public ExerciseTransformation exerciseTransformation;
    public bool run = false;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "MyMesh";
        vertices = new Vector3[4];
        Reset();

        int[] triangles = new int[6];
        triangles[0] = 0; // p1
        triangles[1] = 3; // p4
        triangles[2] = 1; // p2
        triangles[3] = 0; // p1
        triangles[4] = 2; // p3
        triangles[5] = 3; // p4
        mesh.triangles = triangles;

        // Add a Mesh Renderer component to the Mesh object
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create a new material that uses a green color
        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.green;

        // Assign the material to the Mesh object
        meshRenderer.material = material;
    }

    void Update()
    {
        if (run)
        {
            run = false;
            Reset();

            switch (exerciseTransformation)
            {
                case ExerciseTransformation.ReflectionY:
                    {
                        ReflectY();
                        break;
                    }
                case ExerciseTransformation.ReflectionX:
                    {
                        ReflectX();
                        break;
                    }
                default: break;
            }
        }
    }

    void Reset()
    {
        vertices[0] = new Vector3(p1.x, p1.y, 1);
        vertices[1] = new Vector3(p2.x, p2.y, 1);
        vertices[2] = new Vector3(p3.x, p3.y, 1);
        vertices[3] = new Vector3(p4.x, p4.y, 1);
        mesh.vertices = vertices;
    }

    #region Exercise Transformations

    void ReflectY()
    {
        float[,] mat = new float[2, 2];
        mat[0, 0] = -1; mat[0, 1] = 0;
        mat[1, 0] = 0;  mat[1, 1] = 1;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }

    void ReflectX()
    {
        float[,] mat = new float[2, 2];
        mat[0, 0] = 1;  mat[0, 1] = 0;
        mat[1, 0] = 0;  mat[1, 1] = -1;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }


    #endregion

}