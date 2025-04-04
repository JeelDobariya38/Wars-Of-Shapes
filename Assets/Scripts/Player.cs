using TMPro;
using UnityEngine;

namespace WarsOfShapes
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _scoreTextGameOverPanel;
        [SerializeField] private int _maxHealth = 100;
        
        private HealthSystem _healthSystem;

        public HealthSystem HealthSystem => _healthSystem;

        private void Awake() 
        {
            _healthSystem = new HealthSystem(_maxHealth);

            _healthSystem.OnHealthChanged += HandleHealthChanged;
            _healthSystem.OnNoHealth += HandlePlayerDeath;

            UpdateHealthText(_healthSystem.GetHealth());
            _scoreSystem.StartScoring();
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth) 
        {
            UpdateHealthText(currentHealth);
        }

        private void HandlePlayerDeath() 
        {
            _scoreTextGameOverPanel.text = "Score: " + _scoreSystem.GetScore();
            _gameManager.GameOver();
            _scoreSystem.StopScoring();
        }

        private void UpdateHealthText(int healthValue) 
        {
            _healthText.text = $"Health: {healthValue}";
        }
    }
}
