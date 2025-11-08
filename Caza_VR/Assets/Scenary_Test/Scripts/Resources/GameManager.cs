using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager poolManager;

    public Transform[] respawnPosition;
    public int respawnPos = 0;
    public GameObject player;

    public bool pistol = false;
    public bool scythe = false;
    public bool sword = false;

    public bool sObject = true;
    public bool systemActive = true;
    public int enemiesKilled=0;
    public int bulletsFired=0;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        poolManager = GetComponent<PoolManager>();
    }
    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    //Items Room
    public void InsideObject(bool state)
    {
        sObject = state;
    }
    public void OffWalls(GameObject[] objects)
    {
        foreach(var obj in objects)
        {
            if(obj != null)
                obj.SetActive(false);
        }
        systemActive = false;
    }

    //Respawn
    IEnumerator Respawn()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = respawnPosition[respawnPos].position;
        player.SetActive(true);
    }
    public void Res()
    {
        StartCoroutine(Respawn());
    }
}
