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


    private List<Vector3> nukitsukeKiritsukeMoves = new List<Vector3>() { new Vector3(-0.5f, 0.8f, 0.5f), new Vector3(0f, 0.8f, 0.5f), new Vector3(0.5f, 0.8f, 0.5f), };

    void Start()
    {
        switch (trainingType)
        {
            case TrainingType.NukitsukeKiritsuke:
                foreach (Vector3 move in nukitsukeKiritsukeMoves)
                {
                    trainingSteps.Add(Instantiate(trainingStepPrefab, move + playerPosition.position, Quaternion.identity));
                }
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
