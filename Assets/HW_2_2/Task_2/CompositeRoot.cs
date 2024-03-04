using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW_2_2.Task_2
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private int _playerHealth = 100;
        [SerializeField] private int _playerStartLevel = 1;

        [Space]
        [SerializeField] private HealthView _healthView;
        [SerializeField] private CharacterLevelView _levelView;
        [SerializeField] private ResetPanel _resetPanel;
        [SerializeField] private ControlPanel _controlPanel;

        private List<IDisposable> _disposables = new List<IDisposable>();

        public void Start()
        {
            var health = new Health(_playerHealth);
            var characterLevel = new CharacterLevel(_playerStartLevel);

            var player = new Player(health, characterLevel);

            var playerMediator = new PlayerMediator(player, _healthView, _levelView, _controlPanel, _resetPanel);

            _resetPanel.Init(playerMediator);
            _controlPanel.Init(playerMediator);

            _disposables.Add(playerMediator);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}