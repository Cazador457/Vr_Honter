using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health;

    public event Action<Enemy> onDeath;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AddValue();
            Die();
            gameObject.SetActive(false);
        }
    }

    public virtual void Die()=> onDeath?.Invoke(this);

    public virtual void OnEnable()=> health = 50f;

    public virtual void AddValue()=> GameManager.Instance.enemiesKilled++;
}
