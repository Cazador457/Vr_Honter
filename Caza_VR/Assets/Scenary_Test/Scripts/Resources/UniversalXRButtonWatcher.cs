using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }

public class UniversalXRButtonWatcher : MonoBehaviour
{
    public enum XRButton
    {
        PrimaryButton,
        SecondaryButton,
        TriggerButton,
        GripButton,
        MenuButton,
        Primary2DAxisClick,
        Secondary2DAxisClick
    }

    [Header("Configuración")]
    public XRButton buttonToWatch = XRButton.TriggerButton;

    [Header("Evento")]
    public BoolEvent onButtonEvent;

    private List<InputDevice> devices;
    private bool lastState = false;

    private void Awake()
    {
        if (onButtonEvent == null)
            onButtonEvent = new BoolEvent();

        devices = new List<InputDevice>();
    }

    private void OnEnable()
    {
        InputDevices.deviceConnected += OnDeviceConnected;
        InputDevices.deviceDisconnected += OnDeviceDisconnected;

        List<InputDevice> all = new List<InputDevice>();
        InputDevices.GetDevices(all);

        foreach (var device in all)
            OnDeviceConnected(device);
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= OnDeviceConnected;
        InputDevices.deviceDisconnected -= OnDeviceDisconnected;
        devices.Clear();
    }

    private void OnDeviceConnected(InputDevice device)
    {
        bool check;
        if (TryGetFeatureValue(device, out check))
            devices.Add(device);
    }

    private void OnDeviceDisconnected(InputDevice device)
    {
        if (devices.Contains(device))
            devices.Remove(device);
    }

    void Update()
    {
        bool tempState = false;

        foreach (var device in devices)
        {
            bool value;
            if (TryGetFeatureValue(device, out value) && value)
                tempState = true;
        }

        if (tempState != lastState)
        {
            lastState = tempState;
            onButtonEvent.Invoke(tempState);
        }
    }

    // Traduce el botón elegido a su "CommonUsage"
    private bool TryGetFeatureValue(InputDevice device, out bool value)
    {
        switch (buttonToWatch)
        {
            case XRButton.PrimaryButton:
                return device.TryGetFeatureValue(CommonUsages.primaryButton, out value);

            case XRButton.SecondaryButton:
                return device.TryGetFeatureValue(CommonUsages.secondaryButton, out value);

            case XRButton.TriggerButton:
                return device.TryGetFeatureValue(CommonUsages.triggerButton, out value);

            case XRButton.GripButton:
                return device.TryGetFeatureValue(CommonUsages.gripButton, out value);

            case XRButton.MenuButton:
                return device.TryGetFeatureValue(CommonUsages.menuButton, out value);

            case XRButton.Primary2DAxisClick:
                return device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out value);

            case XRButton.Secondary2DAxisClick:
                return device.TryGetFeatureValue(CommonUsages.secondary2DAxisClick, out value);
        }

        value = false;
        return false;
    }
}
