using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KesagiriTraining : ITraining
{
    private Transform playerPosition;
    private TrainingStep kissakiStepPrefab;
    private TrainingStep rightHandStepPrefab;

    private List<TrainingStep> trainingSteps = new List<TrainingStep>();
    private List<List<Vector3>> kissakiMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.1f, 0.8f, 0.9f),
                                                                                                 new Vector3(0f, 1f, 1.2f),
                                                                                                 new Vector3(0.2f, 1.2f, 1.24f), },
                                                                           new List<Vector3>() { new Vector3(0.5f, 1f, 1.2f),
                                                                                                 new Vector3(0f, 1f, 1.1f),
                                                                                                 new Vector3(-0.6f, 1.25f, 0.53f),
                                                                                                 new Vector3(-0.6f, 1.4f, 0.05f),
                                                                                                 new Vector3(0f, 1.7f, -0.9f),}};

    private List<List<Vector3>> rightHandMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.12f, 0.57f, 0.1f),
                                                                                                   new Vector3(0.04f, 0.8f, 0.45f),
                                                                                                   new Vector3(0.15f, 0.9f, 0.5f),
                                                                                                   new Vector3(0.25f, 1f, 0.5f), },
                                                                             new List<Vector3>() { new Vector3(0.45f, 1f, 0.4f),
                                                                                                   new Vector3(0.34f, 1f, 0.45f),
                                                                                                   new Vector3(0.12f, 1.07f, 0.45f),
                                                                                                   new Vector3(0.02f, 1.2f, 0.4f),
                                                                                                   new Vector3(0f, 1.5f, 0f), }};

    private const int stagesNumber = 2;
    private int currentStage = 0;

    private bool isFinished = false;

    public KesagiriTraining(Transform playerPosition, TrainingStep kissakiStepPrefab, TrainingStep rightHandStepPrefab)
    {
        this.playerPosition = playerPosition;
        this.kissakiStepPrefab = kissakiStepPrefab;
        this.rightHandStepPrefab = rightHandStepPrefab;

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
