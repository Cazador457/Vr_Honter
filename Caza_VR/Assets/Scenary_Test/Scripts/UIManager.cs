using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int maxLife = 3;
    public int currentLife;
    public Image[] lifeSprite;

    public GameObject diePanel;

    public void RestLife()
    {
        currentLife--;
        if (currentLife <= 0)
        {
            
        }
        if (currentLife >= 0)
        {
            
        }
        CurrentLife();
    }
    public void CurrentLife()
    {
        for (int i = 0; i < lifeSprite.Length; i++)
        {
            lifeSprite[i].enabled = i < currentLife;
        }
    }
}
