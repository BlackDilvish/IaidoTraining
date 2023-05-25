#if UNITY_EDITOR
using UnityEditor.Scripting.Python;
using UnityEditor;
using UnityEngine;

public class EditorMenu
{
    [MenuItem("Iaido Editor/Generate Moves Vector")]
    static void GenerateMovesVector()
    {
        Debug.Log("Runnnig python parser...");
        PythonRunner.RunFile($"{Application.dataPath}/Scripts/Parser/parser.py");
        Debug.Log("Move vectors spawned in the parser directory");
    }
}
#endif
