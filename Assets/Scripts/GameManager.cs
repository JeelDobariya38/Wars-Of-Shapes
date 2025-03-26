using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject mainmenu;
    public GameObject gameovermenu;

    public void GameStart() {
        SceneManager.LoadScene(1);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        mainmenu.SetActive(false);
        pausemenu.SetActive(true);
    }

    public void GameResume()
    {
        Time.timeScale = 1f;
        mainmenu.SetActive(true);
        pausemenu.SetActive(false);
    }

    public void GoBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void GameOver() {
        Time.timeScale = 0f;
        gameovermenu.SetActive(true);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Application Quitted!!");
    }
}
