using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapConfigs mapConfigs;
    public MeshGenerator terrainPrefab;
    public GameObject player;

    public enum Direction
    {
        Left, Right, Up, Down, None
    }

    Direction playerDirection;

    private MeshGenerator[,] terrains;

    private Vector2[,] piecesPositions = new Vector2[3, 3];


    void Start()
    {
        terrains = new MeshGenerator[3, 3];

        player.transform.position = new Vector3(mapConfigs.startX, 30, mapConfigs.startZ);

        // Para gerar 9. Caso mude, é necessarior olhar essa parte.
        int currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        int currentZ = mapConfigs.startZ - (mapConfigs.height / 2) - mapConfigs.height;

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                piecesPositions[i, j] = new Vector2(currentX, currentZ);
                terrains[i, j] = Instantiate(terrainPrefab, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                currentX += mapConfigs.width;
            }
            currentZ += mapConfigs.height;
            currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        }
    }

    void Update()
    {
        GenerateNewTerrainPiece();
    }


    void GenerateNewTerrainPiece()
    {
        switch(PlayerDirection())
        {
            case Direction.Right:
                Destroy(terrains[0, 0].gameObject);
                Destroy(terrains[1, 0].gameObject);
                Destroy(terrains[2, 0].gameObject);

                piecesPositions[0, 0] = piecesPositions[0, 1];
                piecesPositions[1, 0] = piecesPositions[1, 1];
                piecesPositions[2, 0] = piecesPositions[2, 1];

                piecesPositions[0, 1] = piecesPositions[0, 2];
                piecesPositions[1, 1] = piecesPositions[1, 2];
                piecesPositions[2, 1] = piecesPositions[2, 2];

                piecesPositions[0, 2] = new Vector2(piecesPositions[0, 1].x + mapConfigs.width, piecesPositions[0, 1].y);
                piecesPositions[1, 2] = new Vector2(piecesPositions[1, 1].x + mapConfigs.width, piecesPositions[1, 1].y);
                piecesPositions[2, 2] = new Vector2(piecesPositions[2, 1].x + mapConfigs.width, piecesPositions[2, 1].y);

                terrains[0, 0] = terrains[0, 1];
                terrains[1, 0] = terrains[1, 1];
                terrains[2, 0] = terrains[2, 1];

                terrains[0, 1] = terrains[0, 2];
                terrains[1, 1] = terrains[1, 2];
                terrains[2, 1] = terrains[2, 2];

                terrains[0, 2] = Instantiate(terrainPrefab, new Vector3(piecesPositions[0, 2].x, 0, piecesPositions[0, 2].y), Quaternion.identity);
                terrains[1, 2] = Instantiate(terrainPrefab, new Vector3(piecesPositions[1, 2].x, 0, piecesPositions[1, 2].y), Quaternion.identity);
                terrains[2, 2] = Instantiate(terrainPrefab, new Vector3(piecesPositions[2, 2].x, 0, piecesPositions[2, 2].y), Quaternion.identity);

                break;
            case Direction.Left:
                Destroy(terrains[0, 2].gameObject);
                Destroy(terrains[1, 2].gameObject);
                Destroy(terrains[2, 2].gameObject);

                piecesPositions[0, 2] = piecesPositions[0, 1];
                piecesPositions[1, 2] = piecesPositions[1, 1];
                piecesPositions[2, 2] = piecesPositions[2, 1];

                piecesPositions[0, 1] = piecesPositions[0, 0];
                piecesPositions[1, 1] = piecesPositions[1, 0];
                piecesPositions[2, 1] = piecesPositions[2, 0];

                piecesPositions[0, 0] = new Vector2(piecesPositions[0, 1].x - mapConfigs.width, piecesPositions[0, 1].y);
                piecesPositions[1, 0] = new Vector2(piecesPositions[1, 1].x - mapConfigs.width, piecesPositions[1, 1].y);
                piecesPositions[2, 0] = new Vector2(piecesPositions[2, 1].x - mapConfigs.width, piecesPositions[2, 1].y);

                terrains[0, 2] = terrains[0, 1];
                terrains[1, 2] = terrains[1, 1];
                terrains[2, 2] = terrains[2, 1];

                terrains[0, 1] = terrains[0, 0];
                terrains[1, 1] = terrains[1, 0];
                terrains[2, 1] = terrains[2, 0];

                terrains[0, 0] = Instantiate(terrainPrefab, new Vector3(piecesPositions[0, 0].x, 0, piecesPositions[0, 0].y), Quaternion.identity);
                terrains[1, 0] = Instantiate(terrainPrefab, new Vector3(piecesPositions[1, 0].x, 0, piecesPositions[1, 0].y), Quaternion.identity);
                terrains[2, 0] = Instantiate(terrainPrefab, new Vector3(piecesPositions[2, 0].x, 0, piecesPositions[2, 0].y), Quaternion.identity);

                break;
            case Direction.Down:
                Destroy(terrains[0, 0].gameObject);
                Destroy(terrains[0, 1].gameObject);
                Destroy(terrains[0, 2].gameObject);

                piecesPositions[0, 0] = piecesPositions[1, 0];
                piecesPositions[0, 1] = piecesPositions[1, 1];
                piecesPositions[0, 2] = piecesPositions[1, 2];

                piecesPositions[1, 0] = piecesPositions[2, 0];
                piecesPositions[1, 1] = piecesPositions[2, 1];
                piecesPositions[1, 2] = piecesPositions[2, 2];

                piecesPositions[2, 0] = new Vector2(piecesPositions[1, 0].x, piecesPositions[1, 0].y - mapConfigs.height);
                piecesPositions[2, 1] = new Vector2(piecesPositions[1, 1].x, piecesPositions[1, 1].y - mapConfigs.height);
                piecesPositions[2, 2] = new Vector2(piecesPositions[1, 2].x, piecesPositions[1, 2].y - mapConfigs.height);

                terrains[0, 0] = terrains[1, 0];
                terrains[0, 1] = terrains[1, 1];
                terrains[0, 2] = terrains[1, 2];

                terrains[1, 0] = terrains[2, 0];
                terrains[1, 1] = terrains[2, 1];
                terrains[1, 2] = terrains[2, 2];

                terrains[2, 0] = Instantiate(terrainPrefab, new Vector3(piecesPositions[2, 0].x, 0, piecesPositions[2, 0].y), Quaternion.identity);
                terrains[2, 1] = Instantiate(terrainPrefab, new Vector3(piecesPositions[2, 1].x, 0, piecesPositions[2, 1].y), Quaternion.identity);
                terrains[2, 2] = Instantiate(terrainPrefab, new Vector3(piecesPositions[2, 2].x, 0, piecesPositions[2, 2].y), Quaternion.identity);

                break;
            case Direction.Up:
                Destroy(terrains[2, 0].gameObject);
                Destroy(terrains[2, 1].gameObject);
                Destroy(terrains[2, 2].gameObject);

                piecesPositions[2, 0] = piecesPositions[1, 0];
                piecesPositions[2, 1] = piecesPositions[1, 1];
                piecesPositions[2, 2] = piecesPositions[1, 2];

                piecesPositions[1, 0] = piecesPositions[0, 0];
                piecesPositions[1, 1] = piecesPositions[0, 1];
                piecesPositions[1, 2] = piecesPositions[0, 2];

                piecesPositions[0, 0] = new Vector2(piecesPositions[1, 0].x, piecesPositions[1, 0].y + mapConfigs.height);
                piecesPositions[0, 1] = new Vector2(piecesPositions[1, 1].x, piecesPositions[1, 1].y + mapConfigs.height);
                piecesPositions[0, 2] = new Vector2(piecesPositions[1, 2].x, piecesPositions[1, 2].y + mapConfigs.height);

                terrains[2, 0] = terrains[1, 0];
                terrains[2, 1] = terrains[1, 1];
                terrains[2, 2] = terrains[1, 2];

                terrains[1, 0] = terrains[0, 0];
                terrains[1, 1] = terrains[0, 1];
                terrains[1, 2] = terrains[0, 2];

                terrains[0, 0] = Instantiate(terrainPrefab, new Vector3(piecesPositions[0, 0].x, 0, piecesPositions[0, 0].y), Quaternion.identity);
                terrains[0, 1] = Instantiate(terrainPrefab, new Vector3(piecesPositions[0, 1].x, 0, piecesPositions[0, 1].y), Quaternion.identity);
                terrains[0, 2] = Instantiate(terrainPrefab, new Vector3(piecesPositions[0, 2].x, 0, piecesPositions[0, 2].y), Quaternion.identity);                
                break;
        }   
        
    }

    public Direction PlayerDirection()
    {
        if(SmallestOfAllX())
        {
            return Direction.Left;
        }
        else if(GreatestOfAllX())
        {
            return Direction.Right;
        }
        else if(SmallestOfAllZ())
        {
            return Direction.Down;
        }
        else if(GreatestOfAllZ())
        {
            return Direction.Up;
        }

        return Direction.None;
    }


    public bool SmallestOfAllZ()
    {
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(player.transform.position.z > piecesPositions[i, j].y + (mapConfigs.width / 2))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool GreatestOfAllZ()
    {
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(player.transform.position.z < piecesPositions[i, j].y )
                {
                    return false;
                }
            }
        }
        return true;
    }



    public bool SmallestOfAllX()
    {
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(player.transform.position.x > piecesPositions[i, j].x + (mapConfigs.width / 2))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool GreatestOfAllX()
    {
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(player.transform.position.x < piecesPositions[i, j].x )
                {
                    return false;
                }
            }
        }
        return true;
    }

}
