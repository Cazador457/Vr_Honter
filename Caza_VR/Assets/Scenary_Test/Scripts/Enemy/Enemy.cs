using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health = 50f;

    public event Action<Enemy> onDeath;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Instance.enemiesKilled++;
            Die();
        }
    }

    public virtual void Die()
    {
        onDeath?.Invoke(this);
    }

    public virtual void OnEnable()
    {
        //Cada vez que se active, restaura vida
        health = 50f;
    }
}
