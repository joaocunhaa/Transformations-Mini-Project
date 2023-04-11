using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidObject : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        // Create mesh
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "MyMesh";

        vertices = new Vector3[18];
        //back triangle vertices
        vertices[0] = new Vector3(-10, 0, -10);
        vertices[1] = new Vector3(10, 0, -10);
        vertices[2] = new Vector3(0, 10, 0);
        //front triangle vertices
        vertices[3] = new Vector3(-10, 0, 10);
        vertices[4] = new Vector3(10, 0, 10);
        vertices[5] = new Vector3(0, 10, 0);
        //left triangle vertices
        vertices[6] = new Vector3(-10, 0, 10);
        vertices[7] = new Vector3(-10, 0, -10);
        vertices[8] = new Vector3(0, 10, 0);
        //right triangle vertices
        vertices[9] = new Vector3(10, 0, 10);
        vertices[10] = new Vector3(10, 0, -10);
        vertices[11] = new Vector3(0, 10, 0);
        //botton triangle 1 vertices
        vertices[12] = new Vector3(-10, 0, -10);
        vertices[13] = new Vector3(10, 0, -10);
        vertices[14] = new Vector3(-10, 0, 10);
        //botton triangle 2 vertices
        vertices[15] = new Vector3(10, 0, 10);
        vertices[16] = new Vector3(10, 0, -10);
        vertices[17] = new Vector3(-10, 0, 10);

        int[] triangles = new int[18];
        //back triangle
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        //front triangle
        triangles[3] = 4;
        triangles[4] = 5;
        triangles[5] = 3;
        //left triangle
        triangles[6] = 6;
        triangles[7] = 8;
        triangles[8] = 7;
        //right triangle
        triangles[9] = 10;
        triangles[10] = 11;
        triangles[11] = 9;
        //bottom triangle 1
        triangles[12] = 13;
        triangles[13] = 14;
        triangles[14] = 12;
        //bottom triangle 2
        triangles[15] = 15;
        triangles[16] = 17;
        triangles[17] = 16;

        Vector3[] normals = new Vector3[18];

        normals[0] = Vector3.back + Vector3.up;
        normals[1] = Vector3.back + Vector3.up;
        normals[2] = Vector3.back + Vector3.up;

        normals[3] = Vector3.forward + Vector3.up;
        normals[4] = Vector3.forward + Vector3.up;
        normals[5] = Vector3.forward + Vector3.up;

        normals[6] = Vector3.left + Vector3.up;
        normals[7] = Vector3.left + Vector3.up;
        normals[8] = Vector3.left + Vector3.up;

        normals[9] = Vector3.right + Vector3.up;
        normals[10] = Vector3.right + Vector3.up;
        normals[11] = Vector3.right + Vector3.up;

        normals[12] = Vector3.down;
        normals[13] = Vector3.down;
        normals[14] = Vector3.down;

        normals[15] = Vector3.down;
        normals[16] = Vector3.down;
        normals[17] = Vector3.down;

        //Update mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;

        // Add a Mesh Renderer component to the Mesh object
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create a new material that uses a green color
        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.grey;

        // Assign the material to the Mesh object
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
