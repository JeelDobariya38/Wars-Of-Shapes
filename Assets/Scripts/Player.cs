using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private int _maxHealth = 100;
    
    private HealthSystem _healthSystem;

    private void Awake() 
    {
        _healthSystem = new HealthSystem(_maxHealth);

        _healthSystem.OnHealthChanged += HandleHealthChanged;
        _healthSystem.OnNoHealth += HandlePlayerDeath;

        UpdateHealthText(_healthSystem.GetHealth());
    }

    public void TakeDamage(int damageAmount) 
    {
        _healthSystem.TakeDamage(damageAmount);
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth) 
    {
        UpdateHealthText(currentHealth);
    }

    private void HandlePlayerDeath() 
    {
        _gameManager.GameOver();
    }

    private void UpdateHealthText(int healthValue) 
    {
        _healthText.text = $"Health: {healthValue}";
    }
}
