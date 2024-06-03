
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<GameController>().ResetGame();
        Time.timeScale = 1;
    }
}
