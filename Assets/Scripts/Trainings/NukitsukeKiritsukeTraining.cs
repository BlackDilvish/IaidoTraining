using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NukitsukeKiritsukeTraining : KissakiAndRightHandTraining
{
    private static List<List<Vector3>> kissakiMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.5f, 1f, 0.9f),
                                                                                                        new Vector3(0f, 1f, 1.2f),
                                                                                                        new Vector3(0.5f, 1f, 1.24f), },
                                                                                  new List<Vector3>() { new Vector3(0.5f, 1f, 1.2f),
                                                                                                        new Vector3(0f, 1f, 1.1f),
                                                                                                        new Vector3(-0.6f, 1.25f, 0.53f),
                                                                                                        new Vector3(-0.6f, 1.4f, 0.05f),
                                                                                                        new Vector3(0f, 1.7f, -0.9f),},
                                                                                  new List<Vector3>() { new Vector3(0f, 1.7f, -0.9f),
                                                                                                        new Vector3(0f, 1.75f, 1f),
                                                                                                        new Vector3(0f, 1.45f, 1.2f),
                                                                                                        new Vector3(0f, 1.1f, 1.28f),
                                                                                                        new Vector3(0f, 0.6f, 1.28f),}};

    private static List<List<Vector3>> rightHandMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.12f, 0.57f, 0.1f),
                                                                                                          new Vector3(0.04f, 0.8f, 0.45f),
                                                                                                          new Vector3(0.15f, 0.9f, 0.5f),
                                                                                                          new Vector3(0.45f, 1f, 0.5f), },
                                                                                    new List<Vector3>() { new Vector3(0.45f, 1f, 0.4f),
                                                                                                          new Vector3(0.34f, 1f, 0.45f),
                                                                                                          new Vector3(0.12f, 1.07f, 0.45f),
                                                                                                          new Vector3(0.02f, 1.2f, 0.4f),
                                                                                                          new Vector3(0f, 1.5f, 0f),},
                                                                                    new List<Vector3>() { new Vector3(0f, 1.5f, 0f),
                                                                                                          new Vector3(0f, 1.15f, 0.5f),
                                                                                                          new Vector3(0f, 0.95f, 0.5f),
                                                                                                          new Vector3(0f, 0.8f, 0.5f),
                                                                                                          new Vector3(0f, 0.6f, 0.5f),}};

    public NukitsukeKiritsukeTraining(Transform playerPosition, TrainingStep kissakiStepPrefab, TrainingStep rightHandStepPrefab)
        : base(playerPosition, kissakiStepPrefab, rightHandStepPrefab, kissakiMoves, rightHandMoves)
    {
    }
}
