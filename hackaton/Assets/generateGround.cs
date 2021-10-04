using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateGround : MonoBehaviour
{
    [SerializeField]
    int scale;
    [SerializeField]
    int resolution;

    int size = 30;
    float dist = 10f;

    Vector3[] newVertices;
    int[] newTriangles;

    // Start is called before the first frame update
    void Start()
    {
        dist = scale / resolution;
        size = resolution;

        GenerateMesh(size);
        ColorMesh();
    }

    void GenerateMesh(int size)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = mesh;

        newVertices = new Vector3[(size + 1) * (size + 1)];
        for (int i = 0, y = 0; y <= size; y++)
        {
            for (int x = 0; x <= size; x++, i++)
            {
                newVertices[i] = new Vector3(x * dist, 0, y * dist);
            }
        }

        newTriangles = new int[6 * size * size];

        for (int ti = 0, vi = 0, y = 0; y < size; y++, vi++)
        {
            for (int x = 0; x < size; x++, ti += 6, vi++)
            {
                newTriangles[ti] = vi;
                newTriangles[ti + 3] = newTriangles[ti + 2] = vi + 1;
                newTriangles[ti + 4] = newTriangles[ti + 1] = vi + size + 1;
                newTriangles[ti + 5] = vi + size + 2;
            }
        }



        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
        mesh.RecalculateNormals();
    }

    void ColorMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            if (i < (size + 1) * (size + 1) / 2) { colors[i] = Color.red; }
            else { colors[i] = Color.green; }

        // assign the array of colors to the Mesh.
        mesh.colors = colors;
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.black;
    //    for (int i = 0; i < newVertices.Length; i++)
    //    {
    //        Gizmos.DrawSphere(newVertices[i], 0.5f);
    //    }
    //}
}
