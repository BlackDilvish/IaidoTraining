using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InputController : MonoBehaviour
{
    //public UnityEngine.XR.InputDevice leftHandDevice;
    public XRNode inputSource;
    public InputHelpers.Button restartButton;
    public float inputThreshold = 0.1f;

    public bool isRestartPressed;

    public InputHelpers.Button debugButton;

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), restartButton, out isRestartPressed, inputThreshold);

        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), debugButton, out bool debugpress, inputThreshold);
        if (debugpress)
        {
            Debug.Log("Position Hand: " + GameObject.Find("Right Hand Position").transform.position 
                    + " Kissaki: " + GameObject.Find("Kissaki").transform.position);
        }
    }
}
