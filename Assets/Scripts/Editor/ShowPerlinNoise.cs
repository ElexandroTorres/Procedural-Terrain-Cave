using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(PerlinNoise))]
public class ShowPerlinNoise : Editor
{
    public override void OnInspectorGUI()
    {
        PerlinNoise noiseMap = (PerlinNoise)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate noise"))
        {
            noiseMap.GenerateNoiseMap();
        }
    }
}
