using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class TerrainPiece : MonoBehaviour
{
    [SerializeField] private List<GameObject> _Colectables;
    [SerializeField] private GameObject _tree;
    [SerializeField] private GameObject _rock;
    [SerializeField] private GameObject _caveEntrace;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
