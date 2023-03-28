using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Transformation2D
{
    None,
    Translate2D,
    Scaling2D,
    ScalingMatrix2D,
    Rotation2D,
    RotationMatrix2D,
    Translate2DMatrixHM,
    Scaling2DMatrixHM,
    Rotation2DMatrixHM
}

public class TriangleMesh : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;

    public Transformation2D transformation2D;
    public bool decrease = false;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "MyMesh";
        vertices = new Vector3[3];
        vertices[0] = new Vector3(3, 0, 1);
        vertices[1] = new Vector3(5, 0, 1);
        vertices[2] = new Vector3(4, 2, 1);
        mesh.vertices = vertices;
        int[] triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        mesh.triangles = triangles;

        // Add a Mesh Renderer component to the Mesh object
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create a new material that uses a pink color
        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.magenta;

        // Assign the material to the Mesh object
        meshRenderer.material = material;
    }

    void Update()
    {
        float factor;
        switch (transformation2D)
        {
            case Transformation2D.Translate2D:
                {
                    factor = decrease ? -1.0f : 1.0f;
                    Translate2D(factor * 2 * Time.deltaTime, 0);
                    break;
                }
            case Transformation2D.Scaling2D:
                {
                    factor = decrease ? 0.99f : 1.01f;
                    Scale2D(factor, 1);
                    break;
                }
            case Transformation2D.ScalingMatrix2D:
                {
                    factor = decrease ? 0.99f : 1.01f;
                    Scale2DMat(factor, factor);
                    break;
                }
            case Transformation2D.Rotation2D:
                {
                    factor = decrease ? -1.0f : 1.0f;
                    Rotate2D(factor * 20 * Mathf.Deg2Rad * Time.deltaTime);
                    break;
                }
            case Transformation2D.RotationMatrix2D:
                {
                    factor = decrease ? -1.0f : 1.0f;
                    Rotate2DMat(factor * 120 * Mathf.Deg2Rad * Time.deltaTime);
                    break;
                }
            case Transformation2D.Translate2DMatrixHM:
                {
                    factor = decrease ? -1.0f : 1.0f;
                    Translate2DMatHM(0, factor * 2 * Time.deltaTime);
                    break;
                }
            case Transformation2D.Scaling2DMatrixHM:
                {
                    factor = decrease ? 0.99f : 1.01f;
                    Scale2DMatHM(1, factor);
                    break;
                }
            case Transformation2D.Rotation2DMatrixHM:
                {
                    factor = decrease ? -1.0f : 1.0f;
                    Rotate2DMatHM(factor * 4 * Mathf.Deg2Rad * Time.deltaTime);
                    break;
                }
            default: break;
        }
    }

    /// <summary>
    /// Applies a transformation matrix to a vector.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="point"></param>
    /// <returns>The transformed vector.</returns>
    Vector3 multiply(float[,] matrix, Vector3 point)
    {
        Vector3 result = new Vector3();
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            float s = 0;
            for (int z = 0; z < matrix.GetLength(1); z++)
                s += matrix[r, z] * point[z];
            result[r] = s;
        }
        return result;
    }

    #region Basic Transformations

    void Translate2D(float tx, float ty)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices[i].x + tx,
                                      vertices[i].y + ty);
        }
        mesh.vertices = vertices;
    }

    void Scale2D(float sx, float sy)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices[i].x * sx,
                                      vertices[i].y * sy);
        }
        mesh.vertices = vertices;
    }

    void Scale2DMat(float sx, float sy)
    {
        float[,] mat = new float[2, 2];
        mat[0, 0] = sx; mat[0, 1] = 0;
        mat[1, 0] = 0; mat[1, 1] = sy;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }

    void Rotate2D(float angle)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices[i].x * Mathf.Cos(angle)
                                   - vertices[i].y * Mathf.Sin(angle),
                                     vertices[i].x * Mathf.Sin(angle)
                                   + vertices[i].y * Mathf.Cos(angle));
        }
        mesh.vertices = vertices;
    }

    void Rotate2DMat(float angle)
    {
        float[,] mat = new float[2, 2];
        mat[0, 0] = Mathf.Cos(angle); mat[0, 1] = -Mathf.Sin(angle);
        mat[1, 0] = Mathf.Sin(angle); mat[1, 1] = Mathf.Cos(angle);
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }

    #endregion


    #region Homogeneous Coordinates

    void Translate2DMatHM(float tx, float ty)
    {
        float[,] mat = new float[3, 3];
        mat[0, 0] = 1; mat[0, 1] = 0; mat[0, 2] = tx;
        mat[1, 0] = 0; mat[1, 1] = 1; mat[1, 2] = ty;
        mat[2, 0] = 0; mat[2, 1] = 0; mat[2, 2] = 1;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }

    void Scale2DMatHM(float sx, float sy)
    {
        float[,] mat = new float[3, 3];
        mat[0, 0] = sx; mat[0, 1] = 0; mat[0, 2] = 0;
        mat[1, 0] = 0; mat[1, 1] = sy; mat[1, 2] = 0;
        mat[2, 0] = 0; mat[2, 1] = 0; mat[2, 2] = 1;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }

    void Rotate2DMatHM(float angle)
    {
        float[,] mat = new float[3, 3];
        mat[0, 0] = Mathf.Cos(angle); mat[0, 1] = -Mathf.Sin(angle); mat[0, 2] = 0;
        mat[1, 0] = Mathf.Sin(angle); mat[1, 1] = Mathf.Cos(angle); mat[1, 2] = 0;
        mat[2, 0] = 0; mat[2, 1] = 0; mat[2, 2] = 1;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(mat, vertices[i]);
        }
        mesh.vertices = vertices;
    }

    #endregion


    #region Combining Transformations

    float[,] multiply(float[,] matrix1, float[,] matrix2)
    {
        float[,] result = new float[matrix1.GetLength(0), matrix2.GetLength(1)];
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                float s = 0;
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    s += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = s;
            }
        }
        return result;
    }

    void RotateScale(float angle, float sx, float sy)
    {
        float[,] rmat = new float[3, 3];
        rmat[0, 0] = Mathf.Cos(angle); rmat[0, 1] = -Mathf.Sin(angle); rmat[0, 2] = 0;
        rmat[1, 0] = Mathf.Sin(angle); rmat[1, 1] = Mathf.Cos(angle); rmat[1, 2] = 0;
        rmat[2, 0] = 0; rmat[2, 1] = 0; rmat[2, 2] = 1;

        float[,] smat = new float[3, 3];
        smat[0, 0] = sx; smat[0, 1] = 0; smat[0, 2] = 0;
        smat[1, 0] = 0; smat[1, 1] = sy; smat[1, 2] = 0;
        smat[2, 0] = 0; smat[2, 1] = 0; smat[2, 2] = 1;

        float[,] finalmat = multiply(smat, rmat);
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = multiply(finalmat, vertices[i]);
        }
        mesh.vertices = vertices;
    }


    #endregion

}