using System.Collections.Generic;
using UnityEngine;

public class SogiriTraining : KissakiAndRightHandTraining
{
    private static List<List<Vector3>> rightHandMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.1f, 0.57f, 0.17f),
                                                                                                          new Vector3(-0.03f, 0.6f, 0.3f)},
                                                                                    new List<Vector3>() { new Vector3(-0.03f, 0.89f, 0.3f),
                                                                                                          new Vector3(0f, 1.25f, 0.33f),
                                                                                                          new Vector3(0.1f, 1.55f, 0.22f),
                                                                                                          new Vector3(0.11f, 1.57f, 0.22f)},
                                                                                    new List<Vector3>() { new Vector3(0.14f, 1.51f, 0.28f),
                                                                                                          new Vector3(-0.02f, 0.99f, 0.58f),
                                                                                                          new Vector3(-0.07f, 0.80f, 0.6f)},
                                                                                    new List<Vector3>() { new Vector3(-0.01f, 1.51f, 0.22f),
                                                                                                          new Vector3(-0.04f, 1.09f, 0.5f),
                                                                                                          new Vector3(0.03f, 0.84f, 0.5f),
                                                                                                          new Vector3(0.00f, 0.75f, 0.5f),
                                                                                                          new Vector3(0.06f, 0.71f, 0.47f),},
                                                                                    new List<Vector3>() { new Vector3(0.09f, 1.53f, 0.25f),
                                                                                                          new Vector3(0.06f, 1.09f, 0.52f),
                                                                                                          new Vector3(0.03f, 0.84f, 0.51f),
                                                                                                          new Vector3(0.00f, 0.71f, 0.49f),
                                                                                                          new Vector3(-0.08f, 0.55f, 0.38f),},
                                                                                    new List<Vector3>() { new Vector3(-0.30f, 0.60f, 0.24f),
                                                                                                          new Vector3(-0.09f, 0.6f, 0.44f),
                                                                                                          new Vector3(0.02f, 0.6f, 0.42f),
                                                                                                          new Vector3(0.20f, 0.6f, 0.34f),
                                                                                                          new Vector3(0.41f, 0.6f, 0.15f),},
                                                                                    new List<Vector3>() { new Vector3(0f, 1.55f, 0.11f),
                                                                                                          new Vector3(0f, 1.06f, 0.52f),
                                                                                                          new Vector3(0f, 0.85f, 0.52f),
                                                                                                          new Vector3(0f, 0.71f, 0.46f),
                                                                                                          new Vector3(0f, 0.53f, 0.39f)}};


    private static List<List<Vector3>> kissakiMoves = new List<List<Vector3>>() { new List<Vector3>() { new Vector3(-0.24f, 0.54f, -0.67f),
                                                                                                        new Vector3(-0.2f, 0.5f, -0.52f)},
                                                                                  new List<Vector3>() { new Vector3(-0.22f, 0.16f, -0.14f),
                                                                                                        new Vector3(-0.18f, 0.4f, 0.26f),
                                                                                                        new Vector3(-0.53f, 1f, 0.3f),
                                                                                                        new Vector3(-0.67f, 1.23f, 0.3f)},
                                                                                  new List<Vector3>() { new Vector3(0.29f, 2.03f, -0.39f),
                                                                                                        new Vector3(0.18f, 1.60f, 1.15f),
                                                                                                        new Vector3(-0.03f, 1.29f, 1.24f)},
                                                                                  new List<Vector3>() { new Vector3(-0.18f, 1.97f, -0.49f),
                                                                                                        new Vector3(-0.29f, 1.84f, 0.89f),
                                                                                                        new Vector3(-0.14f, 1.34f, 1.23f),
                                                                                                        new Vector3(-0.15f, 1.18f, 1.23f),
                                                                                                        new Vector3(0.01f, 1.07f, 1.24f),},
                                                                                  new List<Vector3>() { new Vector3(0.28f, 2.11f, -0.34f),
                                                                                                        new Vector3(0.28f, 1.82f, 0.98f),
                                                                                                        new Vector3(0.19f, 1.32f, 1.26f),
                                                                                                        new Vector3(0.12f, 1.04f, 1.27f),
                                                                                                        new Vector3(-0.11f, 0.76f, 1.21f),},
                                                                                  new List<Vector3>() { new Vector3(-1.14f, 0.75f, 0.14f),
                                                                                                        new Vector3(-0.63f, 0.76f, 1.10f),
                                                                                                        new Vector3(-0.27f, 0.77f, 1.21f),
                                                                                                        new Vector3(0.51f, 0.76f, 1.10f),
                                                                                                        new Vector3(1.15f, 0.75f, 0.57f),},
                                                                                  new List<Vector3>() { new Vector3(0f, 1.95f, -0.64f),
                                                                                                        new Vector3(0f, 1.81f, 0.93f),
                                                                                                        new Vector3(0f, 1.38f, 1.19f),
                                                                                                        new Vector3(0f, 1.15f, 1.18f),
                                                                                                        new Vector3(0f, 0.68f, 1.23f)}};

    public SogiriTraining(Transform playerPosition, TrainingStep kissakiStepPrefab, TrainingStep rightHandStepPrefab)
        : base(playerPosition, kissakiStepPrefab, rightHandStepPrefab, kissakiMoves, rightHandMoves)
    {
    }
}

