using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }
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
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
