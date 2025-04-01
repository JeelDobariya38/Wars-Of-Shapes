using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private int maxHealth;

    private HealthSystem _healthSystem;

    private void Awake() {
        _healthSystem = new HealthSystem(maxHealth);
        _healthSystem.OnHealthChanged += (currenthealth, maxHealth) => UpdateHealthText(currenthealth);
        _healthSystem.OnNoHealth += () => gameManager.GameOver();
        UpdateHealthText(_healthSystem.GetHealth());
    }

    public void TakeDamage(int damage) {
        _healthSystem.TakeDamage(damage);
    }

    private void UpdateHealthText(int healthValue) {
        healthText.text = "Health: " + healthValue.ToString();
    }
}
