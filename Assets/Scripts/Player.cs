using UnityEngine;

namespace WarsOfShapes
{
    public class Player : MonoBehaviour, IDamageable
    {
        private HealthSystem _healthSystem;
        private ScoreSystem _scoreSystem;

        public HealthSystem HealthSystem => _healthSystem;

        public void Awake()
        {
            Camera.main.GetComponent<CameraFollow>().Init(transform);
            _scoreSystem = GetComponent<ScoreSystem>();

            _healthSystem = new HealthSystem();
            _healthSystem.OnHealthChanged += HandleHealthChanged;
            _healthSystem.OnNoHealth += HandlePlayerDeath;
        }

        public void Init(int speed, int health)
        {
            GetComponent<Movement>().Init(speed);
            _healthSystem.Init(health);
        }

        private void Start()
        {
            _scoreSystem.StartScoring();
        }

        private void OnEnable() {
            
        }

        private void OnDisable() {
            _healthSystem.OnHealthChanged -= HandleHealthChanged;
            _healthSystem.OnNoHealth -= HandlePlayerDeath;
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth) 
        {
            GameMenuManager.Instance.UpdateHealthText(currentHealth);
        }

        private void HandlePlayerDeath() 
        {
            GameMenuManager.Instance.OpenGameOverMenu(_scoreSystem.GetScore());
            _scoreSystem.StopScoring();
        }
    }
}
