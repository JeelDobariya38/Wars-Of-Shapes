using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject mainmenu;


    public void GameStart() {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        mainmenu.SetActive(false);
        pausemenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        mainmenu.SetActive(true);
        pausemenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quitted!!");
    }
}
