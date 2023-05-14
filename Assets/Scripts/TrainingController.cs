using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrainingType
{
    NukitsukeKiritsuke,
    Mae
}

public class TrainingController : MonoBehaviour
{
    [SerializeField]
    private Transform playerPosition;
    private List<TrainingStep> trainingSteps = new List<TrainingStep>();

    [SerializeField]
    private TrainingStep trainingStepPrefab;

    public TrainingType trainingType;
    private ITraining currentTraining;

    void Start()
    {
        
    }

    void Update()
    {
        if (this.currentTraining != null)
        {
            this.currentTraining.Update();

            if (this.currentTraining.IsFinished())
            {
                Debug.Log("Finished training");
            }
        }
    }

    public void StartTraining()
    {
        if (this.currentTraining != null)
        {
            this.currentTraining.Clear();
        }

        switch (trainingType)
        {
            case TrainingType.NukitsukeKiritsuke:
                this.currentTraining = new NukitsukeKiritsukeTraining(playerPosition, trainingStepPrefab);
                break;
            default:
                break;
        }
    }
}
