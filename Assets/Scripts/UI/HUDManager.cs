using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Text label_EnCount;
    public Text label_GameOverMassage;
    public Text playerHP;
    public GameObject GameOver;
    public GameObject Player;
    public GameObject pausePanel;
    string win = "You have won!";
    string gameOver = "Game Over!";
    int monsterCount = 0;

    void Start()
    {
        GameOver.SetActive(false);
        GameObject[] aMonster = GameObject.FindGameObjectsWithTag("Enemy");
        monsterCount = aMonster.Length;
        label_EnCount.text = monsterCount.ToString();
        PauseGame();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(pausePanel.active)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }

        playerHP.text = Player.GetComponent<Player>().currentHealth.ToString();

        if(monsterCount == 0)
        {
            label_GameOverMassage.text = win;
            GameOver.SetActive(true);
        }
        if(Player.GetComponent<Player>().currentHealth <= 0)
        {
            label_GameOverMassage.text = gameOver;
            GameOver.SetActive(true);
        }
    }

    public void UpdateMonsterCount()
    {
        --monsterCount;
        label_EnCount.text = monsterCount.ToString();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Player.GetComponent<PlayerController>().enabled = false;
        pausePanel.SetActive(true);
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        Player.GetComponent<PlayerController>().enabled = true;
        pausePanel.SetActive(false);
    }
}
