using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager poolManager;
    public SaveSystem saveSystem;

    public bool sObject = true;
    public bool systemActive = true;
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
        saveSystem = GetComponent<SaveSystem>();

        if (saveSystem != null)
            saveSystem.LoadData();
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        
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

    //Game Data
    public void SaveGame()
    {
        if (saveSystem != null)
            saveSystem.SaveData();
    }
}
