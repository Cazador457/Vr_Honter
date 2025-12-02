using UnityEngine;

public class hitS : MonoBehaviour
{
    public int playerRes = 0;
    public float damage = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            GameManager.Instance.respawnPos = playerRes;
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            GameManager.Instance.Res();
            Debug.Log("Die");
        }
    }
}
