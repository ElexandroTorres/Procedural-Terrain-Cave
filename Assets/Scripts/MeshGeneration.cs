using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGeneration : MonoBehaviour
{
    Mesh mesh;
    
    private Vector3[] vertices;
    private int[] triangles;

    public int xSize = 50;
    public int zSize = 50;

    public float xPosition;
    public float zPosition;

    void Start()
    {
        xPosition = this.transform.position.x;
        zPosition = this.transform.position.z;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;    
        CreateShape();
        UpdateMesh();
    }

    float CalculatePerlin(float x, float z)
    {
        return Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 2f;
    }

    
    void CreateShape()
    {
        int i = 0;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = CalculatePerlin(xPosition, zPosition);
                vertices[i] = new Vector3(x, y, z);
                i++;
                xPosition++;
            }
            zPosition++;
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

}
