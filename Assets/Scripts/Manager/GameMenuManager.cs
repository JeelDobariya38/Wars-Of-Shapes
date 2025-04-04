using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarsOfShapes
{
    public enum UIPanels {
        GAME_MENU,
        PAUSE_MENU,
        GAMEOVER_MENU
    }

    public class GameMenuManager : MonoBehaviour
    {
        public static GameMenuManager Instance;

        [SerializeField] private GameObject gameMenu;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject gameoverMenu;

        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreTextGameOverPanel;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            { 
                Destroy(this.gameObject); 
            }
            
            Instance = this;
        }

        public void ToggleMenu(UIPanels panel) {
            gameMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gameoverMenu.SetActive(false);

            switch (panel) 
            {
                case UIPanels.GAME_MENU:
                    gameMenu.SetActive(true);
                    break;

                case UIPanels.PAUSE_MENU:
                    pauseMenu.SetActive(true);
                    break;

                case UIPanels.GAMEOVER_MENU:
                    gameoverMenu.SetActive(true);
                    break;
            }
        }

        public void OpenGameOverMenu(int score) {
            Time.timeScale = 0f;
            scoreTextGameOverPanel.text = $"Score: {score}";
            gameoverMenu.SetActive(true);
        }

        public void PauseGame() {
            Time.timeScale = 0f;
            ToggleMenu(UIPanels.PAUSE_MENU);
        }

        public void ResumeGame() {
            Time.timeScale = 1f;
            ToggleMenu(UIPanels.GAME_MENU);
        }

        public void OpenMainMenu() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void RestartCurrentScene() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void UpdateHealthText(int healthValue) 
        {
            healthText.text = $"Health: {healthValue}";
        }

        public void UpdateScoreText(int scoreValue)
        {
            scoreText.text = $"Score: {scoreValue}";
        }
    }
}
