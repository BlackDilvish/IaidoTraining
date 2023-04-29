using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public UnityEngine.XR.InputDevice leftHandDevice;

    private void Update()
    {
        if (! this.leftHandDevice.isValid)
        {
            var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
            if (leftHandDevices.Count == 1)
            {
                this.leftHandDevice = leftHandDevices[0];
                Debug.Log(string.Format("Got reference to device '{0}'", this.leftHandDevice.name));
            }
        }
    }
}
