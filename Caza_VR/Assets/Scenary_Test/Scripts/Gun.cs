using UnityEngine;

public class Gun : MonoBehaviour
{
    enum ForceType { None,AddForce,Inmediate,Impulse}
    enum ShootType { None,Raycast,Proyectile }
    enum BulletType { None,Antipersonal,Antitank,Normal }
    [SerializeField]private ShootType _shootType;
    [SerializeField]private BulletType _bulletType;
}
