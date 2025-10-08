using UnityEngine;
using UnityEngine.XR;

public class Gun : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform FirePoint;
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
        GameObject bullet = Instantiate(bulletPref, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = FirePoint.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
