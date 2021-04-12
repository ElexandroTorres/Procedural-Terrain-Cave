using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Mesh mesh;
    public GameObject mapManager;
    private Vector3[] vertices;
    private int[] triangles;

    public int xSize;
    public int zSize;

    public float xPosition;
    public float zPosition;

    public float scale;

    void Start()
    {
        mesh = new Mesh();

        xSize = mapManager.GetComponent<MapManager>().width;
        zSize = mapManager.GetComponent<MapManager>().height;
        scale = mapManager.GetComponent<MapManager>().scale;

        xPosition = this.transform.position.x;
        zPosition = this.transform.position.z;
        
        GetComponent<MeshFilter>().mesh = mesh;    
        CreateShape();
        UpdateMesh();
    }

    float CalculatePerlin(float x, float z, float scale, int octaves, float persistance)
    {
        //float amplitude  = 1;
        //float frenquency = 1;
        //float height = 0;

        //for(int i = 0; i < octaves; i++)
        //{
            float sampleX = x / scale;
            float sampleZ = z / scale;

            return Mathf.PerlinNoise(sampleX, sampleZ);
            //perlin =  Mathf.PerlinNoise(sampleX, sampleZ);
            //height += perlin * amplitude;
            //amplitude *= persistance;
        //}
        
        
    }

    
    void CreateShape()
    {
        int i = 0;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = PerlinNoise.GenerateNoise(x, z, scale);

                if(y < 0) { y = 0; }
                else if(y > 1) { y = 1; }
                    
                vertices[i] = new Vector3(x, y, z);
                i++;
                //xPosition++;
            }
            //zPosition++;
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
