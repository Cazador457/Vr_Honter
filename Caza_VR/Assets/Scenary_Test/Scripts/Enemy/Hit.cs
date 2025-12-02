using UnityEngine;

public class Hit : MonoBehaviour
{
    public int playerRes = 0;
    public float damage = 1f;
    public GameObject enemy;
    public void Start()
    {
        enemy = this.gameObject;
    }
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
            enemy.SetActive(false);
            Debug.Log("Die");
        }
    }
}
