#if UNITY_EDITOR
using UnityEditor.Scripting.Python;
using UnityEditor;
using UnityEngine;
using System.IO;

public class EditorMenu
{
    [MenuItem("Iaido Editor/Generate Moves Vector")]
    static void GenerateMovesVector()
    {
        Debug.Log("Runnnig python parser...");
        PythonRunner.RunFile($"{Application.dataPath}/Scripts/Parser/parser.py");
        Debug.Log("Move vectors spawned in the parser directory");
    }

    [MenuItem("Iaido Editor/Clear Move Files")]
    static void ClearMoveFiles()
    {
        Debug.Log("Clearing move files...");
        string[] files = Directory.GetFiles(Application.persistentDataPath);

        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            if (fileName.StartsWith("moveData"))
            {
                File.Delete(file);
            }
        }
    }
}
#endif
