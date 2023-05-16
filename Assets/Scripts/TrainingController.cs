using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingController : MonoBehaviour
{
    public enum TrainingType
    {
        NukitsukeKiritsuke,
        Mae,
        Ushiro,
        Ukenagashi,
        Tsukaate,
        Kesagiri,
        Morotetsuki,
        Sanpogiri,
        Ganmenate,
        Soetezuki,
        Shihogiri,
        Sogiri,
        Nukiuchi
    }

    [SerializeField]
    private Transform playerPosition;

    [SerializeField]
    private TrainingStep kissakiStepPrefab;
    [SerializeField]
    private TrainingStep rightHandStepPrefab;

    [SerializeField]
    private Text text;

    public TrainingType trainingType;
    private ITraining currentTraining;

    void Update()
    {
        if (this.currentTraining != null)
        {
            this.currentTraining.Update();

            if (this.currentTraining.IsFinished())
            {
                this.text.text = "Finished: " + this.trainingType.ToString();
                this.currentTraining = null;
            }
        }
    }

    public void StartTraining()
    {
        this.ExitTraining();

        this.text.text = "Current training sequence: " + this.trainingType.ToString();
        switch (this.trainingType)
        {
            case TrainingType.NukitsukeKiritsuke:
                this.currentTraining = new NukitsukeKiritsukeTraining(playerPosition, kissakiStepPrefab, rightHandStepPrefab);
                break;
            case TrainingType.Kesagiri:
                this.currentTraining = new KesagiriTraining(playerPosition, kissakiStepPrefab, rightHandStepPrefab);
                break;
            case TrainingType.Sogiri:
                this.currentTraining = new SogiriTraining(playerPosition, kissakiStepPrefab, rightHandStepPrefab);
                break;
            default:
                Debug.LogWarning("Training not implemented: " + this.trainingType.ToString());
                break;
        }
    }

    public void ExitTraining()
    {
        this.text.text = "";
        if (this.currentTraining != null)
        {
            this.currentTraining.Clear();
            this.currentTraining = null;
        }
    }

    public void SetTrainingType(int type)
    {
        Debug.Log("Picked the next training: " + type);
        this.trainingType = (TrainingType)type;
    }
}
