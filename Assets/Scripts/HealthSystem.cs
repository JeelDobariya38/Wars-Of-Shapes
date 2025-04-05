using System;
using UnityEngine;

namespace WarsOfShapes
{
    public class HealthSystem
    {
        private int _currentHealth;
        private int _maxHealth;

        public event Action<int, int> OnHealthChanged; // (currentHealth, maxHealth)

        public event Action OnNoHealth;

        public HealthSystem(int maxHealth)
        {
            _currentHealth = maxHealth;
            SetMaxHealth(maxHealth);
        }

        public void SetMaxHealth(int maxHealth) {
            if (_currentHealth > maxHealth) {
                _currentHealth = maxHealth;
            }
            _maxHealth = maxHealth;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        public bool IsAlive() {
            return _currentHealth > 0;
        }

        public int GetHealth() {
            return _currentHealth;
        }

        public void TakeDamage(int damage)
        {
            if (_currentHealth <= 0) return;

            _currentHealth -= damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth == 0)
            {
                OnNoHealth?.Invoke();
            }
        }

        public void Heal(int healAmount)
        {
            _currentHealth += healAmount;
            _currentHealth = Mathf.Min(_currentHealth, _maxHealth);

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        public void Reset()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}
