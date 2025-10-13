using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public string bulletTag = "Bullet";
    public float bulletSpeed = 10f;

    public InputActionProperty triggerAction;

    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            GameManager.Instance.poolManager.SpawnFromPool(bulletTag, firePoint.position, firePoint.rotation);
            Debug.Log("Disparando");
            //if (fireSound != null) fireSound.Play();
        }
    }
}
