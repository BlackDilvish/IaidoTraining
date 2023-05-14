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

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), restartButton, out isRestartPressed, inputThreshold);

    }
}
