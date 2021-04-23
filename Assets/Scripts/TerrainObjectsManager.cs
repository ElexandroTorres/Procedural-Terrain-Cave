using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObjectsManager : MonoBehaviour
{
    float[,] objectsMap;
    GameObject treePrefab;
    GameObject rockPrefab;

    int x;
    int z;

    public TerrainObjectsManager(float[,] map, int x, int z, GameObject tree, GameObject rock, GameObject cave)
    {
        objectsMap = map;
        treePrefab = tree;
        x = x;
        z = z;
    }

    public void SpawnObjects()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(treePrefab, new Vector3(x, objectsMap[z, x] , z), Quaternion.identity);
        }
    }

    
}
