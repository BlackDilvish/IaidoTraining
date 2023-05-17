using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private float inputThreshold = 0.1f;
    [SerializeField]
    private XRNode inputSource;

    [SerializeField]
    private InputHelpers.Button restartButton;
    public bool isRestartPressed;

    [SerializeField]
    private InputHelpers.Button debugButton;
    public bool isDebugPressed;

    [SerializeField]
    private InputHelpers.Button debugButton2;
    public bool isDebug2Pressed;

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), restartButton, out isRestartPressed, inputThreshold);

        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), debugButton, out isDebugPressed, inputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), debugButton2, out isDebug2Pressed, inputThreshold);
        //if (debugpress)
        //{
        //    Debug.Log("Position Hand: " + GameObject.Find("Right Hand Position").transform.position 
        //            + " Kissaki: " + GameObject.Find("Kissaki").transform.position);
        //}
    }
}
