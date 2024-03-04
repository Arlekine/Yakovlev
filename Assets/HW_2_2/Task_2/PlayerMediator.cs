using System;

namespace HW_2_2.Task_2
{
    public class PlayerMediator : IDisposable
    {
        private Player _player;

        private HealthView _healthView;
        private CharacterLevelView _characterLevelView;
        private ControlPanel _controlPanel;
        private ResetPanel _resetPanel;

        public PlayerMediator(Player player, HealthView healthView, CharacterLevelView characterLevelView, ControlPanel controlPanel, ResetPanel resetPanel)
        {
            _player = player;
            _healthView = healthView;
            _characterLevelView = characterLevelView;
            _controlPanel = controlPanel;
            _resetPanel = resetPanel;

            _player.Health.HealthChanged += OnHealthChanged;
            _player.Health.Died += OnDied;
            _player.CharacterLevel.LevelChanged += OnLevelIncreased;

            _healthView.SetValues(_player.Health.CurrentHealth, _player.Health.MaxHealth);
            _characterLevelView.SetLevel(_player.CharacterLevel.CurrentLevel);

            _controlPanel.Show();
            _resetPanel.Hide();
        }

        public void DamagePlayer(int damage)
        {
            _player.Health.Damage(damage);
        }

        public void HealPlayer(int heal)
        {
            _player.Health.Heal(heal);
        }

        public void LevelUpPlayer()
        {
            _player.CharacterLevel.IncreaseLevel();
        }

        public void Reset()
        {
            _player.Reset();

            _controlPanel.Show();
            _resetPanel.Hide();
        }

        public void Dispose()
        {
            _player.Health.HealthChanged -= OnHealthChanged;
            _player.Health.Died -= OnDied;
            _player.CharacterLevel.LevelChanged -= OnLevelIncreased;
        }

        private void OnHealthChanged(int currentHealth)
        {
            _healthView.SetValues(currentHealth, _player.Health.MaxHealth);
        }

        private void OnDied()
        {
            _controlPanel.Hide();
            _resetPanel.Show();
        }

        private void OnLevelIncreased(int currentLevel)
        {
            _characterLevelView.SetLevel(currentLevel);
        }
    }
}