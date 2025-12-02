using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    //public UI ui;
    public int maxLife = 3;
    public int currentLife;
    public Image[] lifeSprite;

    public GameObject diePanel;
    public GameObject pausePanel;
    void Start()
    {
        diePanel.SetActive(false);
        pausePanel.SetActive(false);
        CurrentLife();
    }

    void Update()
    {
        LifeValue();
    }
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



    public float health = 3f;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            diePanel.SetActive(true);
        }
    }
    public void PauseSh()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
    }
    public int playerRes = 0;
    public void Reset()
    {
        GameManager.Instance.enemiesKilled = 0;
        GameManager.Instance.eSpetialKilled = 0;
        GameManager.Instance.respawnPos = playerRes;
        diePanel.SetActive(false);
        pausePanel.SetActive(false);
        GameManager.Instance.Res();
    }
    public int playerQuit = 10;
    public void Quit()
    {
        GameManager.Instance.enemiesKilled = 0;
        GameManager.Instance.eSpetialKilled = 0;
        GameManager.Instance.respawnPos = playerQuit;
        diePanel.SetActive(false);
        pausePanel.SetActive(false);
        GameManager.Instance.Res();
    }

    public void DieSh()
    {
        diePanel.SetActive(true);
        
    }
    public TextMeshProUGUI healtUI;
    public void LifeValue() => healtUI.text = $"{health}";
}
