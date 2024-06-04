using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIbyKhoa : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int live = 3;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI LiveText;
    [SerializeField] GameObject GameOverPanel;

    private static UIbyKhoa instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }
  
    //tang diem
    public void AddScore(int scoreToadd)
    {
        score += scoreToadd;
        UpdateUI();
    }


    private void DescreaseLive()
    {     
        live--;
        UpdateUI();
 
        if (live >= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            ShowOverPanel();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    public void ResetLives()
    {
        live = 3;
        UpdateUI();
    }

    public void Resetgame()
    {
        ResetLives();
        ResetScore();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PlayerDeath()
    {
        DescreaseLive();
        if (live <= 0)
        {
            ShowOverPanel();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ShowOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void HideGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
        }
    }

    private void UpdateUI()
    {
        if (LiveText != null)
        {
            LiveText.text = live.ToString();
        }

        if (ScoreText != null)
        {
            ScoreText.text = score.ToString();
        }
    }

}
