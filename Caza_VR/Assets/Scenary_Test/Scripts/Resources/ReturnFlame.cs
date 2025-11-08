using UnityEngine;

public class ReturnFlame : MonoBehaviour
{
    public int ress = 4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.respawnPos = ress;
            GameManager.Instance.Res();
            Debug.Log("lograste Salir");
        }
    }
}
