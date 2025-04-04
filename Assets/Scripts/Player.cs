using TMPro;
using UnityEngine;

namespace WarsOfShapes
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private ScoreSystem scoreSystem;
        
        private HealthSystem _healthSystem;

        public HealthSystem HealthSystem => _healthSystem;

        private void Awake() 
        {
            _healthSystem = new HealthSystem(maxHealth);

            _healthSystem.OnHealthChanged += HandleHealthChanged;
            _healthSystem.OnNoHealth += HandlePlayerDeath;
        }

        private void Start()
        {
            GameMenuManager.Instance.UpdateHealthText(_healthSystem.GetHealth());
            scoreSystem.StartScoring();   
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth) 
        {
            GameMenuManager.Instance.UpdateHealthText(currentHealth);
        }

        private void HandlePlayerDeath() 
        {
            GameMenuManager.Instance.OpenGameOverMenu(scoreSystem.GetScore());
            scoreSystem.StopScoring();
        }
    }
}
