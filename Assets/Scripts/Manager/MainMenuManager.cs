using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarsOfShapes
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject creditMenu;

        public void OpenGameScene() {
            SceneManager.LoadScene(1);
        }

        public void OpenMainMenu() {
            creditMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void OpenCreditMenu() {
            mainMenu.SetActive(false);
            creditMenu.SetActive(true);
        }

        public void OpenHyperLink(String url) {
            Application.OpenURL(url);
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Application Quitted!!");
        }
    }
}
