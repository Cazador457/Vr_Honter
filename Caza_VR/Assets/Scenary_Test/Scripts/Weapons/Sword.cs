using UnityEngine;

public class Sword : MonoBehaviour
{
    public Enemy enemy;
    public float Damage = 50f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
            gameObject.SetActive(false);
        }
    }
}
