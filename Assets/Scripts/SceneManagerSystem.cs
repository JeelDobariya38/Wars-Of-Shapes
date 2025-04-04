using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarsOfShapes
{
    public class SceneManagerSystem : MonoBehaviour
    {
        public static SceneManagerSystem Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(int buildIndex)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(buildIndex);
        }

        public void RestartCurrentScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void OpenHyperlink(string url)
        {
            Application.OpenURL(url);
        }
    }
}
