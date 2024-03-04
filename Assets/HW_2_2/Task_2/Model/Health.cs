using System;
using UnityEngine;

namespace HW_2_2.Task_2
{
    public class Health
    {
        private int _maxHealth;
        private int _currentHealth;

        public Health(int maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentException($"{nameof(maxHealth)} should be positive");

            _maxHealth = _currentHealth = maxHealth;
        }

        public event Action<int> HealthChanged;
        public event Action Died;

        public int MaxHealth => _maxHealth;

        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                HealthChanged?.Invoke(_currentHealth);
            }
        }

        public void Heal(int heal)
        {
            if (heal <= 0)
                throw new ArgumentException($"{nameof(heal)} should be positive");

            CurrentHealth = Mathf.Min(_currentHealth + heal, MaxHealth);
        }

        public void Damage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentException($"{nameof(damage)} should be positive");

            CurrentHealth = Mathf.Max(_currentHealth - damage, 0);

            if (_currentHealth == 0)
                Died?.Invoke();
        }

        public void Reset()
        {
            CurrentHealth = _maxHealth;
        }
    }
}