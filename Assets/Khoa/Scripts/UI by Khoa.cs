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


    private void Awake()
    {
        int numGameSession = FindObjectsOfType<UIbyKhoa>().Length;

        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LiveText.text = live.ToString();
        ScoreText.text = score.ToString();
    }

  
    //tang diem
    public void AddScore(int scoreToadd)
    {
        score += scoreToadd;
        ScoreText.text += score.ToString();
    }


    private void DescreaseLive()
    {
        live--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LiveText.text = live.ToString();
    }

    private void Resetgame()
    {
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }

    public void PlayerDeath()
    {
        if (live > 1)
        {
           DescreaseLive();
        }else
        {
            Resetgame();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
