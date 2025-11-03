using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnPoints : MonoBehaviour
{
    public string enemyTag;
    public float spawnInterval = 6f;
    public int maxEnemies = 8;

    public List<Transform> spawnPoints = new List<Transform>();

    public float spawnCheckRadius = 1.5f;
    public LayerMask enemyLayer;
    public int currentEnemies;
    public float nextSpawn;

    public Transform[] patrolRoute;

    void Start()
    {
        nextSpawn = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawn && currentEnemies < maxEnemies)
        {
            TrySpawn();
            nextSpawn = Time.time + spawnInterval;
        }
    }
    void TrySpawn()
    {
        //Lista de puntos disponibles
        List<Transform> validPoints = new List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            if (point == null) continue;

            //Detecta si ya hay un enemigo cerca de ese punto
            Collider[] hits = Physics.OverlapSphere(point.position, spawnCheckRadius, enemyLayer);

            if (hits.Length == 0)
                validPoints.Add(point);
        }

        if (validPoints.Count == 0)
        {
            //No hay puntos libres, no spawnea esta vez
            return;
        }

        //Elige un punto libre al azar
        Transform spawnPoint = validPoints[Random.Range(0, validPoints.Count)];

        //Genera el enemigo desde el PoolManager
        GameObject newEnemy = GameManager.Instance.poolManager.SpawnFromPool(enemyTag, spawnPoint.position, spawnPoint.rotation);

        if (newEnemy != null)
        {
            currentEnemies++;

            //Asocia el evento de muerte
            Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.onDeath += OnEnemyDeath;
            }
        }
    }
    public void SpawnEnemy()
    {
        Transform[] selectedRoute = patrolRoute;

        PoolManager.Instance.SpawnFromPool(
            "Enemy",
            transform.position,
            Quaternion.identity,
            selectedRoute
        );
    }
    void OnEnemyDeath()
    {
        currentEnemies--;
        GameManager.Instance.saveSystem.stats.enemiesKilled++;
        GameManager.Instance.SaveGame();
    }
}
