using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarsOfShapes
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pausemenu;
        [SerializeField] private GameObject _mainmenu;
        [SerializeField] private GameObject _gameovermenu;

        public void GameStart() {
            SceneManager.LoadScene(1);
        }

        public void OpenHyperLink(String url) {
            Application.OpenURL(url);
        }

        public void GameRestart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GamePause()
        {
            Time.timeScale = 0f;
            _mainmenu.SetActive(false);
            _pausemenu.SetActive(true);
        }

        public void GameResume()
        {
            Time.timeScale = 1f;
            _mainmenu.SetActive(true);
            _pausemenu.SetActive(false);
        }

        public void GoBack()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void GameOver() {
            Time.timeScale = 0f;
            _gameovermenu.SetActive(true);
        }

        public void GameQuit()
        {
            Application.Quit();
            Debug.Log("Application Quitted!!");
        }
    }
}
