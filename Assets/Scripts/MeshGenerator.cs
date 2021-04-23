﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public MapConfigs mapConfigs;
    public AnimationCurve heightCurve;
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

                if(_heightMap[z, x] <= 0.4f) 
                    Instantiate(tree, new Vector3(x, _heightMap[z, x] * mapConfigs.heightMutiplier, z), Quaternion.identity);
 
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
        _mesh.uv = _uvs;

        _mesh.RecalculateNormals();
    }

}
