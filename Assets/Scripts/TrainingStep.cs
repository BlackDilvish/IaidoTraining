using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStep : MonoBehaviour
{
    [SerializeField]
    private Color idleColor;
    [SerializeField]
    private Color activatedColor;

    public bool isActivated = false;

    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", idleColor);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.gameObject.name);

        if (other.gameObject.name == "Kissaki")
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", activatedColor);
            this.isActivated = true;
        }
    }
}
