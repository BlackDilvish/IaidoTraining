using System.Collections.Generic;
using UnityEngine;

public class KesagiriTraining : KissakiAndRightHandTraining
{
    private static List<List<Vector3>> kissakiMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.3f, 0.5f, -0.6f),
                                                                                                        new Vector3(-0.3f, 0.37f, -0.22f),
                                                                                                        new Vector3(-0.3f, 0.6f, 0.9f),
                                                                                                        new Vector3(-0.1f, 1.1f, 1.1f),
                                                                                                        new Vector3(0.05f, 1.55f, 1.14f),},
                                                                                  new List<Vector3>() { new Vector3(0.33f, 2.1f, 0f),
                                                                                                        new Vector3(0.1f, 1.5f, 1.2f),
                                                                                                        new Vector3(-0.25f, 1f, 1.25f),
                                                                                                        new Vector3(-0.5f, 0.64f, 1.15f)}};

    private static List<List<Vector3>> rightHandMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.22f, 0.57f, 0.17f),
                                                                                                          new Vector3(-0.16f, 0.84f, 0.48f),
                                                                                                          new Vector3(0f, 1.25f, 0.5f),
                                                                                                          new Vector3(0.07f, 1.4f, 0.4f),
                                                                                                          new Vector3(0.13f, 1.48f, 0.3f),},
                                                                                    new List<Vector3>() { new Vector3(0.09f, 1.4f, 0.4f),
                                                                                                          new Vector3(-0.07f, 0.94f, 0.55f),
                                                                                                          new Vector3(-0.16f, 0.73f, 0.46f),
                                                                                                          new Vector3(-0.23f, 0.53f, 0.33f)}};

    public KesagiriTraining(Transform playerPosition, TrainingStep kissakiStepPrefab, TrainingStep rightHandStepPrefab)
        : base(playerPosition, kissakiStepPrefab, rightHandStepPrefab, kissakiMoves, rightHandMoves)
    {
    }
}
