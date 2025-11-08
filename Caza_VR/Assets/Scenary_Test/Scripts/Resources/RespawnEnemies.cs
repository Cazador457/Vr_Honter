using UnityEngine;
using System.Collections;

public class RespawnEnemies : MonoBehaviour
{
    public GameObject[] objectsToCheck;
    public Transform[] respawnPoints;
    public float respawnTime = 3f;

    // Para recordar qué objetos ya están esperando respawn
    private bool[] isRespawning;

    private void Start()
    {
        isRespawning = new bool[objectsToCheck.Length];
    }

    private void Update()
    {
        EnemyState();
    }

    private void EnemyState()
    {
        for (int i = 0; i < objectsToCheck.Length; i++)
        {
            GameObject obj = objectsToCheck[i];

            // Si está desactivado y NO se está haciendo respawn…
            if (!obj.activeSelf && !isRespawning[i])
            {
                StartCoroutine(RespawnObject(obj, i));
            }
        }
    }

    private IEnumerator RespawnObject(GameObject obj, int index)
    {
        // Marcamos que ya se lanzó su respawn
        isRespawning[index] = true;

        yield return new WaitForSeconds(respawnTime);

        // Punto aleatorio
        int p = Random.Range(0, respawnPoints.Length);

        // Preparar posición ANTES de activar
        obj.transform.position = respawnPoints[p].position;
        obj.transform.rotation = respawnPoints[p].rotation;

        // Activar
        obj.SetActive(true);

        // Marcar como listo de nuevo
        isRespawning[index] = false;
    }
}