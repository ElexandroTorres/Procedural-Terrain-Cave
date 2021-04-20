using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;
    private float[,] heightMap;
    public MapConfigs mapConfigs;

    // TESTE
    public GameObject cavePrefab;
    

    public int xSize;
    public int zSize;

    public int xPosition;
    public int zPosition;

    public float scale;

    public int octaves;

    public float persistance;

    public float lacunarity;

    void Start()
    {
        mesh = new Mesh();
        
        xPosition = (int)this.transform.position.x;
        zPosition = (int)this.transform.position.z;

        xSize = mapConfigs.width;
        zSize = mapConfigs.height;
        scale = mapConfigs.scale;
        octaves = mapConfigs.octaves;
        persistance = mapConfigs.persistance;
        this.lacunarity = mapConfigs.lacunarity;
        
        GetComponent<MeshFilter>().mesh = mesh;    
        CreateShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void CreateShape()
    {
        int i = 0;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        //heightMap = PerlinNoise.GenerateNoiseMap(xSize + 1, zSize + 1, xPosition, zPosition, scale, octaves, persistance, lacunarity);
        heightMap = PerlinNoise.GenerateNoise(xSize + 1, zSize + 1, xPosition, zPosition, scale, octaves, persistance);
        //heightMap = PerlinNoise.GenerateNoiseTeste(xSize + 1, zSize + 1, scale, xPosition, zPosition);

        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //float y = PerlinNoise.GenerateNoise(x, z, scale, octaves, persistance);

                //if(y < 0) { y = 0; }
                //else if(y > 1) { y = 1; }
                  
                vertices[i] = new Vector3(x, heightMap[z, x] * 15, z);
                //teste
                if(heightMap[z, x] < 0.3)
                {
                    Instantiate(cavePrefab, new Vector3(x, heightMap[z, x] * 15, z), Quaternion.identity);
                }
                //teste
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

        uvs = new Vector2[vertices.Length];

        i = 0;
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
    }

}
