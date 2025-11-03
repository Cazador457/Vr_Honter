using System;
using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    public static Action OnDie;
    public float LifeTime = 4f;
    public float Speed = 1f;
    public float Damage = 1f;
    public Vector3 direction;
    private Rigidbody rb;
    private Coroutine corLife;
    void OnEnable()
    {
        Prepare();
    }
    void Prepare()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
        if(corLife == null){StopCoroutine((corLife));}
        corLife = StartCoroutine(Life(LifeTime));
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb.linearVelocity = direction * Speed;
    }

    IEnumerator Life(float _life)
    {
        yield return new WaitForSeconds(_life);
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        //mandar el evento para que el observador lo rgrese al cartucho
        if(OnDie!=null){OnDie.Invoke();}
    }
}
