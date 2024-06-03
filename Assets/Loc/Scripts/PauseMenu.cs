
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        pauseMenu.SetActive(false);
        FindObjectOfType<GameController>().ResetScore();
        FindObjectOfType<GameController>().ResetLives ();
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pauseMenu.SetActive(false);
        var gameController = FindObjectOfType<GameController>();
        gameController.ResetScore();
        gameController.ResetLives();
        gameController.HideGameOverPanel();
        SceneManager.LoadScene("Scene 1");
        Time.timeScale = 1;
    }
}
