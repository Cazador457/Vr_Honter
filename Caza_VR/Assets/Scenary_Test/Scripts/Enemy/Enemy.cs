using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health = 50f;
    public event Action onDeath;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        onDeath?.Invoke();

        gameObject.SetActive(false);
        health = 50f;
    }
    public virtual void OnEnable()
    {
        health = 50f;
    }
}
