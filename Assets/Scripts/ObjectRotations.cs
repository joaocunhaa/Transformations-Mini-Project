using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Transformation3D
{
    None,
    RotationX3DEuler,
    RotationY3DEuler,
    RotationZ3DEuler,
    RotationX3DQuaternions,
    RotationY3DQuaternions,
    RotationZ3DQuaternions
}

public class ObjectRotations : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] normals;

    public Transformation3D transformation3D;
    public bool invert = false;

    // Start is called before the first frame update
    void Start()
    {
        // Create mesh
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "MyMesh";

        vertices = new Vector3[60];
        //back triangle vertices
        vertices[0] = new Vector3(-10, 20, -10);
        vertices[1] = new Vector3(10, 20, -10);
        vertices[2] = new Vector3(0, 30, 0);
        //front triangle vertices
        vertices[3] = new Vector3(-10, 20, 10);
        vertices[4] = new Vector3(10, 20, 10);
        vertices[5] = new Vector3(0, 30, 0);
        //left triangle vertices
        vertices[6] = new Vector3(-10, 20, 10);
        vertices[7] = new Vector3(-10, 20, -10);
        vertices[8] = new Vector3(0, 30, 0);
        //right triangle vertices
        vertices[9] = new Vector3(10, 20, 10);
        vertices[10] = new Vector3(10, 20, -10);
        vertices[11] = new Vector3(0, 30, 0);
        //bottom triangle 1 vertices
        vertices[12] = new Vector3(-10, 20, -10);
        vertices[13] = new Vector3(10, 20, -10);
        vertices[14] = new Vector3(-10, 20, 10);
        //bottom triangle 2 vertices
        vertices[15] = new Vector3(10, 20, 10);
        vertices[16] = new Vector3(10, 20, -10);
        vertices[17] = new Vector3(-10, 20, 10);
        //back triangle inverted vertices
        vertices[18] = new Vector3(-10, 10, -10);
        vertices[19] = new Vector3(10, 10, -10);
        vertices[20] = new Vector3(0, 0, 0);
        //front triangle inverted vertices
        vertices[21] = new Vector3(-10, 10, 10);
        vertices[22] = new Vector3(10, 10, 10);
        vertices[23] = new Vector3(0, 0, 0);
        //left triangle inverted vertices
        vertices[24] = new Vector3(-10, 10, 10);
        vertices[25] = new Vector3(-10, 10, -10);
        vertices[26] = new Vector3(0, 0, 0);
        //right triangle inverted vertices
        vertices[27] = new Vector3(10, 10, 10);
        vertices[28] = new Vector3(10, 10, -10);
        vertices[29] = new Vector3(0, 0, 0);
        //bottom triangle 1 inverted vertices
        vertices[30] = new Vector3(-10, 10, -10);
        vertices[31] = new Vector3(10, 10, -10);
        vertices[32] = new Vector3(-10, 10, 10);
        //bottom triangle 2 inverted vertices
        vertices[33] = new Vector3(10, 10, 10);
        vertices[34] = new Vector3(10, 10, -10);
        vertices[35] = new Vector3(-10, 10, 10);
        //back triangle cube
        vertices[36] = new Vector3(-10, 20, -10);
        vertices[37] = new Vector3(10, 20, -10);
        vertices[38] = new Vector3(-10, 10, -10);
        //back triangle 2 cube
        vertices[39] = new Vector3(10, 10, -10);
        vertices[40] = new Vector3(10, 20, -10);
        vertices[41] = new Vector3(-10, 10, -10);
        //front triangle cube
        vertices[42] = new Vector3(-10, 20, 10);
        vertices[43] = new Vector3(10, 20, 10);
        vertices[44] = new Vector3(-10, 10, 10);
        //front triangle 2 cube
        vertices[45] = new Vector3(10, 10, 10);
        vertices[46] = new Vector3(10, 20, 10);
        vertices[47] = new Vector3(-10, 10, 10);
        //right triangle cube
        vertices[48] = new Vector3(10, 20, 10);
        vertices[49] = new Vector3(10, 20, -10);
        vertices[50] = new Vector3(10, 10, 10);
        //right triangle 2 cube
        vertices[51] = new Vector3(10, 10, 10);
        vertices[52] = new Vector3(10, 20, -10);
        vertices[53] = new Vector3(10, 10, -10);
        //left triangle cube
        vertices[54] = new Vector3(-10, 20, 10);
        vertices[55] = new Vector3(-10, 20, -10);
        vertices[56] = new Vector3(-10, 10, 10);
        //left triangle 2 cube
        vertices[57] = new Vector3(-10, 10, 10);
        vertices[58] = new Vector3(-10, 20, -10);
        vertices[59] = new Vector3(-10, 10, -10);

        int[] triangles = new int[60];
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
        //back triangle inverted
        triangles[18] = 18;
        triangles[19] = 19;
        triangles[20] = 20;
        //front triangle inverted
        triangles[21] = 23;
        triangles[22] = 22;
        triangles[23] = 21;
        //left triangle inverted
        triangles[24] = 26;
        triangles[25] = 24;
        triangles[26] = 25;
        //right triangle inverted
        triangles[27] = 29;
        triangles[28] = 28;
        triangles[29] = 27;
        //bottom triangle 1 inverted
        triangles[30] = 32;
        triangles[31] = 31;
        triangles[32] = 30;
        //bottom triangle 2 inverted
        triangles[33] = 33;
        triangles[34] = 34;
        triangles[35] = 35;
        //back triangle cube
        triangles[36] = 36;
        triangles[37] = 37;
        triangles[38] = 38;
        //back triangle 2 cube
        triangles[39] = 40;
        triangles[40] = 39;
        triangles[41] = 41;
        //front triangle cube
        triangles[42] = 43;
        triangles[43] = 42;
        triangles[44] = 44;
        //front triangle 2 cube
        triangles[45] = 45;
        triangles[46] = 46;
        triangles[47] = 47;
        //right triangle cube
        triangles[48] = 50;
        triangles[49] = 49;
        triangles[50] = 48;
        //right triangle 2 cube
        triangles[51] = 53;
        triangles[52] = 52;
        triangles[53] = 51;
        //left triangle cube
        triangles[54] = 54;
        triangles[55] = 55;
        triangles[56] = 56;
        //left triangle 2 cube
        triangles[57] = 57;
        triangles[58] = 58;
        triangles[59] = 59;

        normals = new Vector3[60];

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

        normals[18] = Vector3.back + Vector3.up;
        normals[19] = Vector3.back + Vector3.up;
        normals[20] = Vector3.back + Vector3.up;

        normals[21] = Vector3.forward + Vector3.up;
        normals[22] = Vector3.forward + Vector3.up;
        normals[23] = Vector3.forward + Vector3.up;

        normals[24] = Vector3.left + Vector3.up;
        normals[25] = Vector3.left + Vector3.up;
        normals[26] = Vector3.left + Vector3.up;

        normals[27] = Vector3.right + Vector3.up;
        normals[28] = Vector3.right + Vector3.up;
        normals[29] = Vector3.right + Vector3.up;

        normals[30] = Vector3.down;
        normals[31] = Vector3.down;
        normals[32] = Vector3.down;

        normals[33] = Vector3.down;
        normals[34] = Vector3.down;
        normals[35] = Vector3.down;

        // Update mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.RecalculateNormals();

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
        float factor;
        switch (transformation3D)
        {
            case Transformation3D.RotationX3DEuler:
                factor = invert ? -1.0f : 1.0f;
                RotateX3D(factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                break;

            case Transformation3D.RotationY3DEuler:
                factor = invert ? -1.0f : 1.0f;
                RotateY3D(factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                break;

            case Transformation3D.RotationZ3DEuler:
                factor = invert ? -1.0f : 1.0f;
                RotateZ3D(factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                break;

            case Transformation3D.RotationX3DQuaternions:
                factor = invert ? -1.0f : 1.0f;
                Rotate3DQuaternions(new Vector3(1, 0, 0), factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                break;

            case Transformation3D.RotationY3DQuaternions:
                factor = invert ? -1.0f : 1.0f;
                Rotate3DQuaternions(new Vector3(0, 1, 0), factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                break;

            case Transformation3D.RotationZ3DQuaternions:
                factor = invert ? -1.0f : 1.0f;
                Rotate3DQuaternions(new Vector3(0, 0, 1), factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                break;

            default: break;
        }
    }

    void RotateX3D(float angle)
    {
        float cosA = Mathf.Cos(angle);
        float sinA = Mathf.Sin(angle);
        for (int i = 0; i < vertices.Length; i++)
        {
            float y = vertices[i].y;
            float z = vertices[i].z;
            vertices[i].y = y * cosA - z * sinA;
            vertices[i].z = y * sinA + z * cosA;

            y = normals[i].y;
            z = normals[i].z;
            normals[i].y = y * cosA - z * sinA;
            normals[i].z = y * sinA + z * cosA;
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
    }

    void RotateY3D(float angle)
    {
        float cosA = Mathf.Cos(angle);
        float sinA = Mathf.Sin(angle);
        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x;
            float z = vertices[i].z;
            vertices[i].x = x * cosA + z * sinA;
            vertices[i].z = -x * sinA + z * cosA;

            x = normals[i].x;
            z = normals[i].z;
            normals[i].x = x * cosA + z * sinA;
            normals[i].z = -x * sinA + z * cosA;
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
    }

    void RotateZ3D(float angle)
    {
        float cosA = Mathf.Cos(angle);
        float sinA = Mathf.Sin(angle);
        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x;
            float y = vertices[i].y;
            vertices[i].x = x * cosA - y * sinA;
            vertices[i].y = x * sinA + y * cosA;

            x = normals[i].x;
            y = normals[i].y;
            normals[i].x = x * cosA - y * sinA;
            normals[i].y = x * sinA + y * cosA;
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
    }

    void Rotate3DQuaternions(Vector3 axis, float angle)
    {
        Quaternion q = AngleAxisToQuaternion(angle, axis);
        Matrix4x4 rotationMatrix = QuaternionToMatrix(q);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = rotationMatrix.MultiplyPoint(vertices[i]);
            normals[i] = rotationMatrix.MultiplyVector(normals[i]);
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
    }

    Quaternion AngleAxisToQuaternion(float angle, Vector3 axis)
    {
        axis.Normalize();
        float sinHalfAngle = Mathf.Sin(angle / 2);
        float cosHalfAngle = Mathf.Cos(angle / 2);

        float x = axis.x * sinHalfAngle;
        float y = axis.y * sinHalfAngle;
        float z = axis.z * sinHalfAngle;
        float w = cosHalfAngle;

        return new Quaternion(x, y, z, w);
    }

    Matrix4x4 QuaternionToMatrix(Quaternion q)
    {
        float xx = q.x * q.x;
        float yy = q.y * q.y;
        float zz = q.z * q.z;
        float xy = q.x * q.y;
        float xz = q.x * q.z;
        float yz = q.y * q.z;
        float wx = q.w * q.x;
        float wy = q.w * q.y;
        float wz = q.w * q.z;

        Matrix4x4 m = new Matrix4x4();
        m.SetRow(0, new Vector4(1.0f - 2.0f * (yy + zz), 2.0f * (xy - wz), 2.0f * (xz + wy), 0.0f));
        m.SetRow(1, new Vector4(2.0f * (xy + wz), 1.0f - 2.0f * (xx + zz), 2.0f * (yz - wx), 0.0f));
        m.SetRow(2, new Vector4(2.0f * (xz - wy), 2.0f * (yz + wx), 1.0f - 2.0f * (xx + yy), 0.0f));
        m.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
        return m;
    }

    // Visualise the normals
    private void OnDrawGizmos()
    {
        if (vertices == null) return;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(vertices[i], normals[i]);
        }
    }
}