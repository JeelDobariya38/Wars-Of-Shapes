using TMPro;
using UnityEngine;

namespace WarsOfShapes
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI scoreTextGameOverPanel;
        
        private HealthSystem _healthSystem;

        public HealthSystem HealthSystem => _healthSystem;

        private void Awake() 
        {
            _healthSystem = new HealthSystem(maxHealth);

            _healthSystem.OnHealthChanged += HandleHealthChanged;
            _healthSystem.OnNoHealth += HandlePlayerDeath;

            UpdateHealthText(_healthSystem.GetHealth());
            scoreSystem.StartScoring();
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth) 
        {
            UpdateHealthText(currentHealth);
        }

        private void HandlePlayerDeath() 
        {
            scoreTextGameOverPanel.text = "Score: " + scoreSystem.GetScore();
            gameManager.GameOver();
            scoreSystem.StopScoring();
        }

        private void UpdateHealthText(int healthValue) 
        {
            healthText.text = $"Health: {healthValue}";
        }
    }
}
