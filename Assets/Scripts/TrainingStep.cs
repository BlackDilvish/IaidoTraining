using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStep : MonoBehaviour
{
    public enum ActivationType
    {
        Kissaki,
        RightHand
    }

    [SerializeField]
    private Color idleColor;
    [SerializeField]
    private Color activatedColor;
    [SerializeField]
    private ActivationType activationType;

    public bool isActivated = false;

    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", idleColor);
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((activationType == ActivationType.Kissaki && other.gameObject.name == "Kissaki")
         || (activationType == ActivationType.RightHand && other.gameObject.name == "Right Hand Position"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", activatedColor);
            this.isActivated = true;
        }
    }
}
