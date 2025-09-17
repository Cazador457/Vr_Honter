using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float LifeTime = 4f;
    public float Speed = 1f;
    public float Damage = 1;
    private Vector3 direction;
    private Rigidbody rb;

    void Start()
    {
        Prepare();
    }
    void Prepare()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {

        rb.linearVelocity = direction * Speed;
    }
}
