
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
        GameController.Instance.ResetScore();
        GameController.Instance.ResetLives();
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
        GameController.Instance.ResetScore();
        GameController.Instance.ResetLives();
        GameController.Instance.HideGameOverPanel();
        SceneManager.LoadScene("Scene 1");
        Time.timeScale = 1;
    }
}