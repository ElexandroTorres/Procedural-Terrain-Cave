using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{
    public MapConfigs mapConfigs;
    private Mesh _mesh;
    private Vector3[] _vertices;
    private int[] _triangles;
    private Vector2[] _uvs;
    private float[,] _heightMap;
    private int _xPosition;
    private int _zPosition;

    //testes
    public GameObject tree;
    public GameObject rock;

    public GameObject cave;

    void Start()
    {
        _xPosition = (int)this.transform.position.x;
        _zPosition = (int)this.transform.position.z;

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;   
        
        CreateMeshShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = _mesh;


        SpawnObjects();
    }
    
    void CreateMeshShape()
    {
        int current = 0;
        _vertices = new Vector3[(mapConfigs.width + 1) * (mapConfigs.height + 1)];
        //heightMap = PerlinNoise.GenerateNoiseMap(xSize + 1, zSize + 1, xPosition, zPosition, scale, octaves, persistance, lacunarity);
        _heightMap = NoiseGenerator.GenerateNoise(mapConfigs.width + 1, mapConfigs.height + 1, _xPosition, _zPosition,
            mapConfigs.scale, mapConfigs.octaves, mapConfigs.persistance);
        //heightMap = PerlinNoise.GenerateNoiseTeste(xSize + 1, zSize + 1, scale, xPosition, zPosition);

        for (int z = 0; z <= mapConfigs.height; z++)
        {
            for (int x = 0; x <= mapConfigs.width; x++)
            {   
                _vertices[current] = new Vector3(x, _heightMap[z, x] * mapConfigs.heightMutiplier, z);
 
                current++;
            }
        }

        _triangles = new int[mapConfigs.width * mapConfigs.height * 6];

        int index = 0;
        int currentVertex = 0;

        for (int z = 0; z < mapConfigs.height; z++)
        {
            for (int x = 0; x < mapConfigs.width; x++)
            {
                _triangles[index] = currentVertex;
                _triangles[index + 1] = mapConfigs.width + 1 + currentVertex;
                _triangles[index +2] = currentVertex + 1;

                _triangles[index +3] = currentVertex + 1;
                _triangles[index +4] = mapConfigs.width + 1 + currentVertex;
                _triangles[index +5] = mapConfigs.width + 2 + currentVertex; 

                index += 6;
                currentVertex++;
            }
            currentVertex++;
        }

        _uvs = new Vector2[_vertices.Length];

        current = 0;
        for (int z = 0; z <= mapConfigs.height; z++)
        {
            for (int x = 0; x <= mapConfigs.width; x++)
            {
                _uvs[current] = new Vector2((float)x / mapConfigs.width, (float)z / mapConfigs.height);
                current++;
            }
        }
    }

    private void UpdateMesh()
    {
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        //_mesh.uv = _uvs;

        _mesh.RecalculateNormals();
    }


    private void SpawnObjects()
    {
        int xx = _xPosition;
        int zz = _zPosition;

        int caveCount = 0;

        int distanceBetweenTrees = 5;

        Random.seed = _xPosition + _zPosition;

        for (int z = 0; z <= mapConfigs.height; z++)
        {
            for (int x = 0; x <= mapConfigs.width; x++)
            {   
                if(_heightMap[z, x] < 0.2f && caveCount == 0)
                {
                    GameObject newCave = Instantiate(cave, new Vector3(xx, _heightMap[z, x] * mapConfigs.heightMutiplier + 5, zz), Quaternion.identity);
                    newCave.transform.parent = this.transform;
                    caveCount++;
                }
                else if(_heightMap[z, x] < 0.35f)
                {
                    GameObject newTree = Instantiate(tree, new Vector3(xx, _heightMap[z, x] * mapConfigs.heightMutiplier + 3, zz), Quaternion.identity);
                    newTree.transform.parent = this.transform;
                }
                else if(_heightMap[z, x] < 0.4f)
                {
                    GameObject newRock = Instantiate(rock, new Vector3(xx, _heightMap[z, x] * mapConfigs.heightMutiplier, zz), Quaternion.identity);
                    newRock.transform.parent = this.transform;
                }
                
                distanceBetweenTrees = Random.Range(10, 20);
                xx += distanceBetweenTrees;
                x += distanceBetweenTrees;
            }
            xx = _xPosition;
            zz+= distanceBetweenTrees;
            z += distanceBetweenTrees;
        }
    }

}
