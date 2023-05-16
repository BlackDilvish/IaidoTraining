using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KissakiAndRightHandTraining : ITraining
{
    private Transform playerPosition;
    private TrainingStep kissakiStepPrefab;
    private TrainingStep rightHandStepPrefab;

    private List<TrainingStep> trainingSteps = new List<TrainingStep>();
    private List<List<Vector3>> kissakiMoves;
    private List<List<Vector3>> rightHandMoves;

    private readonly int stagesNumber;
    private int currentStage = 0;

    private bool isFinished = false;

    public KissakiAndRightHandTraining(Transform playerPosition,
        TrainingStep kissakiStepPrefab, TrainingStep rightHandStepPrefab,
        List<List<Vector3>> kissakiMoves, List<List<Vector3>> rightHandMoves)
    {
        this.playerPosition = playerPosition;
        this.kissakiStepPrefab = kissakiStepPrefab;
        this.rightHandStepPrefab = rightHandStepPrefab;

        this.kissakiMoves = kissakiMoves;
        this.rightHandMoves = rightHandMoves;

        this.stagesNumber = kissakiMoves.Count;

        this.Initialize();
    }

    public void Initialize()
    {
        this.StartStage(0);
    }

    public void Update()
    {
        bool finishedStage = trainingSteps.All(step => step.isActivated);
        if (finishedStage && currentStage < stagesNumber - 1)
        {
            this.Clear();
            this.StartStage(++this.currentStage);
        }
        else if (finishedStage && currentStage == stagesNumber - 1)
        {
            Debug.Log("Finished training");
            this.Clear();
            this.isFinished = true;
        }
    }

    public bool IsFinished()
    {
        return this.isFinished;
    }

    private void StartStage(int stage)
    {
        Debug.Log("Starting step: " + stage);
        foreach (Vector3 move in this.kissakiMoves[stage])
        {
            this.trainingSteps.Add(GameObject.Instantiate(this.kissakiStepPrefab, move + this.playerPosition.position, Quaternion.identity));
        }

        foreach (Vector3 move in this.rightHandMoves[stage])
        {
            this.trainingSteps.Add(GameObject.Instantiate(this.rightHandStepPrefab, move + this.playerPosition.position, Quaternion.identity));
        }
    }

    public void Clear()
    {
        foreach (TrainingStep step in this.trainingSteps)
        {
            GameObject.Destroy(step.gameObject);
        }

        this.trainingSteps.Clear();
    }
}
