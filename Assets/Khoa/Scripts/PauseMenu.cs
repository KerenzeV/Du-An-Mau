using System.Collections;
using System.Collections.Generic;
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
        FindObjectOfType<UIbyKhoa>().ResetScore();
        FindObjectOfType<UIbyKhoa>().ResetLives();
        FindObjectOfType<UIbyKhoa>().HideGameOverPanel();
        SceneManager.LoadScene(1);
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
        var uiByKhoa = FindObjectOfType<UIbyKhoa>();
        uiByKhoa.ResetScore();
        uiByKhoa.ResetLives();
        uiByKhoa.HideGameOverPanel();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
