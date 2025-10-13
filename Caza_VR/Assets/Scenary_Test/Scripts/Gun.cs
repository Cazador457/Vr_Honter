using UnityEngine;
using UnityEngine.XR;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public string bulletTag = "Bullet";
    public GameObject bulletPref;
    public float bulletSpeed = 10f;
    public XRNode controllerNode = XRNode.RightHand;
    private InputDevice device;

    private void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }
    private void Update()
    {
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(controllerNode);
        }
        if(device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed) && triggerPressed)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameManager.Instance.poolManager.SpawnFromPool(bulletTag, firePoint.position, firePoint.rotation);
    }
}
