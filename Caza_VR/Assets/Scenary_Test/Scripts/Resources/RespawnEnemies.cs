using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnEnemies : MonoBehaviour
{
    public Enemy[] enemies;
    public Transform[] respawnPoints;
    public float respawntime = 2f;

    // Para evitar respawns duplicados
    private HashSet<Enemy> waitingRespawn = new HashSet<Enemy>();

    private void Start()
    {
        // Nos suscribimos a los eventos de cada enemigo
        foreach (var e in enemies)
        {
            e.onDeath += HandleEnemyDeath;
        }
    }

    private void HandleEnemyDeath(Enemy enemy)
    {
        // Evitar iniciar dos corrutinas del mismo enemigo
        if (!waitingRespawn.Contains(enemy))
        {
            waitingRespawn.Add(enemy);
            StartCoroutine(Respawn(enemy));
        }
    }

    private IEnumerator Respawn(Enemy enemy)
    {
        yield return new WaitForSeconds(respawntime);

        int i = Random.Range(0, respawnPoints.Length);

        // Posicionarlo ANTES de activarlo
        enemy.transform.position = respawnPoints[i].position;
        enemy.transform.rotation = respawnPoints[i].rotation;

        enemy.gameObject.SetActive(true);

        // Lo sacamos de la lista de espera
        waitingRespawn.Remove(enemy);
    }
}
