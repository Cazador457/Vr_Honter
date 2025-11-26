using UnityEngine;

public class EnemySpetial : EnemyMele
{
    public override void OnEnable()=> health = 1800f;
    public override void AddValue()=> GameManager.Instance.eSpetialKilled++;

}
