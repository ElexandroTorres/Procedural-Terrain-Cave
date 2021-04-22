using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapConfigs))]
public class NoiseConfigsVisualize : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //NoiseTexture testando = (NoiseTexture)target;
        if(GUILayout.Button("TESTE"))
        {
          //  testando.teste();
        }

        //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
    }

    
}