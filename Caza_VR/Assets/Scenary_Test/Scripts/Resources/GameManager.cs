using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager poolManager;

    public Transform[] respawnPosition;
    public int respawnPos = 0;
    public GameObject player;
    public GameObject pistol;
    public GameObject pistol2;
    public Transform pistolRes;
    public Transform pistolRes2;

    public GameObject[] zone1;
    public GameObject[] zone2;
    public GameObject[] zone3;

    public bool actObject = false;
    public bool systemDesactive = false;

    public bool sObject = true;
    public bool systemActive = true;
    public int enemiesKilled=0;
    public int bulletsFired=0;

    public TextMeshProUGUI enemyKV;
    public int eSpetialKilled = 0;
    public TextMeshProUGUI eSpetialKV;

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
        Application.targetFrameRate = 120;
    }
    public void Update()
    {
        EnemyKValue();
        ESpetialKValue();
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

    //Active GO
    public void ActiveObject(bool state)
    {
        actObject = state;
    }
    public void OnWalls(GameObject[] objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
        systemDesactive = true;
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

    //Weapon Return
    public void WReturn()
    {
        StartCoroutine(PistolRes());
        StartCoroutine(PistolRes2());
    }
    public void WReturn2()
    {
        StartCoroutine(PistolRes2());
    }
    IEnumerator PistolRes()
    {
        pistol.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        pistol.transform.position = pistolRes.position;
        pistol.SetActive(true);
    }
    IEnumerator PistolRes2()
    {
        pistol2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        pistol2.transform.position = pistolRes2.position;
        pistol2.SetActive(true);
    }

    //UI
    public void EnemyKValue() => enemyKV.text = $"{enemiesKilled}";

    public void ESpetialKValue() => eSpetialKV.text = $"{eSpetialKilled}";
}
