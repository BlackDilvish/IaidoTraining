using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NukitsukeKiritsukeTraining : ITraining
{
    private Transform playerPosition;
    private TrainingStep stepPrefab;

    private List<TrainingStep> trainingSteps = new List<TrainingStep>();
    private List<List<Vector3>> nukitsukeKiritsukeMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.5f, 1f, 0.8f),
                                                                                                            new Vector3(0f, 1f, 1.2f),
                                                                                                            new Vector3(0.5f, 1f, 1.24f), },
                                                                                      new List<Vector3>() { new Vector3(0.5f, 1f, 1.2f),
                                                                                                            new Vector3(0f, 1f, 1.1f),
                                                                                                            new Vector3(-0.6f, 1.28f, 0.53f),
                                                                                                            new Vector3(-0.6f, 1.5f, 0.05f),
                                                                                                            new Vector3(0f, 1.8f, -0.7f),},
                                                                                      new List<Vector3>() { new Vector3(0f, 1.8f, -0.7f),
                                                                                                            new Vector3(0f, 1.75f, 1f),
                                                                                                            new Vector3(0f, 1.45f, 1.2f),
                                                                                                            new Vector3(0f, 1.1f, 1.28f),
                                                                                                            new Vector3(0f, 0.6f, 1.28f),}};

    private const int stagesNumber = 3;
    private int currentStage = 0;

    private bool isFinished = false;

    public NukitsukeKiritsukeTraining(Transform playerPosition, TrainingStep stepPrefab)
    {
        this.playerPosition = playerPosition;
        this.stepPrefab = stepPrefab;

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
        foreach (Vector3 move in this.nukitsukeKiritsukeMoves[stage])
        {
            trainingSteps.Add(GameObject.Instantiate(this.stepPrefab, move + this.playerPosition.position, this.playerPosition.rotation));
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
