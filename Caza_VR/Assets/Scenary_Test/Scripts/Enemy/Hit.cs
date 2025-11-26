using UnityEngine;

public class Hit : MonoBehaviour
{
    public int playerRes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.enemiesKilled = 0;
            GameManager.Instance.eSpetialKilled = 0;
            GameManager.Instance.respawnPos = playerRes;
            GameManager.Instance.Res();
            Debug.Log("Die");
        }
    }
}
