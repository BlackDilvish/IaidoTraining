using System.IO;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Vector3MovesWrapper
{
    public List<Vector3> rightHandMoves;
    public List<Vector3> kissakiMoves;

    public Vector3MovesWrapper(List<Vector3> rightHandMoves, List<Vector3> kissakiMoves)
    {
        this.rightHandMoves = rightHandMoves;
        this.kissakiMoves = kissakiMoves;
    }
}

public class TrainingEditor : MonoBehaviour
{
    [SerializeField]
    private InputController inputController;
    private bool wasDebugPressed;
    private bool wasDebug2Pressed;

    [SerializeField]
    private TrainingStep kissakiStepPrefab;
    [SerializeField]
    private TrainingStep rightHandStepPrefab;

    private List<TrainingStep> trainingSteps = new List<TrainingStep>();
    private List<Vector3> rightHandMoves = new List<Vector3>();
    private List<Vector3> kissakiMoves = new List<Vector3>();

    private int stepCounter = 0;
    private string fileName = "moveData";

    private void Update()
    {
        if (inputController.isDebugPressed && !this.wasDebugPressed)
        {
            this.AddCurrentPositionToStep();
            this.wasDebugPressed = true;
        }
        else if (!inputController.isDebugPressed && this.wasDebugPressed)
        {
            this.wasDebugPressed = false;
        }

        if (inputController.isDebug2Pressed && !this.wasDebug2Pressed)
        {
            this.SaveCurrentStep();
            this.wasDebug2Pressed = true;
        }
        else if (!inputController.isDebug2Pressed && this.wasDebug2Pressed)
        {
            this.wasDebug2Pressed = false;
        }
    }

    public void AddCurrentPositionToStep()
    {
        Vector3 rightHandPosition = GameObject.Find("Right Hand Position").transform.position;
        this.rightHandMoves.Add(rightHandPosition);
        this.trainingSteps.Add(GameObject.Instantiate(this.rightHandStepPrefab, rightHandPosition, Quaternion.identity));

        Vector3 kissakiPosition = GameObject.Find("Kissaki").transform.position;
        this.kissakiMoves.Add(kissakiPosition);
        this.trainingSteps.Add(GameObject.Instantiate(this.kissakiStepPrefab, kissakiPosition, Quaternion.identity));

        Debug.Log("Current step size: " + rightHandMoves.Count.ToString());
    }

    public void SaveCurrentStep()
    {
        this.SaveToFile(JsonUtility.ToJson(new Vector3MovesWrapper(rightHandMoves, kissakiMoves)));
        this.ClearStep();
        stepCounter++;
    }

    private void SaveToFile(string data)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, fileName + stepCounter.ToString() + ".json");

        using (StreamWriter writer = File.CreateText(fullPath))
        {
            writer.Write(data);
        }

        Debug.Log("Moves saved to file: " + fullPath);
    }

    private void ClearStep()
    {
        foreach(var step in trainingSteps)
        {
            Destroy(step.gameObject);
        }

        trainingSteps.Clear();
        rightHandMoves.Clear();
        kissakiMoves.Clear();
    }
}
