using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGeneration : MonoBehaviour
{
    Mesh mesh;

    private Vector3[] vertices;
    private int[] triangles;

    public int xSize = 500;
    public int zSize = 500;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        CreateShape();
        UpdateMesh();
        
    }

    
    void CreateShape()
    {
        int i = 0;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * xSize * 6];

        int index = 0;
        int currentVertex = 0;

        for (int z = 0; z < zSize; z++)
        {

            for (int x = 0; x < xSize; x++)
            {

                triangles[index] = currentVertex;
                triangles[index + 1] = xSize + 1 + currentVertex;
                triangles[index +2] = currentVertex + 1;

                triangles[index +3] = currentVertex + 1;
                triangles[index +4] = xSize + 1 + currentVertex;
                triangles[index +5] = xSize + 2 + currentVertex; 

                index += 6;
                currentVertex++;


                /*
                triangles = new int[6];
                triangles[0] = 0;
                triangles[1] = xSize + 1;
                triangles[2] = 1;
                triangles[3] = 1;
                triangles[4] = xSize + 1;
                triangles[5] = xSize + 2;    
                */
            }
            currentVertex++;
        }

    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    void OnDrawGizmos()
    {
        if(vertices == null)
            return;

        
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }

    } 
}
