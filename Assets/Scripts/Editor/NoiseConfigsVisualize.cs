using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NoiseTexture))]
public class NoiseConfigsVisualize : Editor
{
    public override void OnInspectorGUI()
    {
        NoiseTexture testando = (NoiseTexture)target;
        if(GUILayout.Button("TESTE"))
        {
            testando.teste();
        }

        //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
    }

    
}