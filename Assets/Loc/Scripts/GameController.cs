using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] int score = 0;
    [SerializeField] int live = 3;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] GameObject gameOverPanel;

    private void Awake()
    {
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateUI();
    }

    private void DecreaseLive()
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
            GameOverPanel();
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

    public void ResetGame()
    {
        ResetLives();
        ResetScore();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ProcessPlayerDeath()
    {
        if (live > 1)
        {
            DecreaseLive();
        }
        else
        {
            GameOverPanel();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void HideGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void UpdateUI()
    {
        if (liveText != null)
        {
            liveText.text = live.ToString();
        }

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}

