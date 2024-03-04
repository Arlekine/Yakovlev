using UnityEngine;
using UnityEngine.UI;

namespace HW_2_2.Task_2
{
    public class ControlPanel : MonoBehaviour
    {
        private const int Damage = 5;
        private const int Heal = 10;

        [SerializeField] private Button _damageButton;
        [SerializeField] private Button _healButton;
        [SerializeField] private Button _levelUpButton;

        private PlayerMediator _playerMediator;

        public void Init(PlayerMediator mediator) => _playerMediator = mediator;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        private void OnEnable()
        {
            _damageButton.onClick.AddListener(OnDamageClick);
            _healButton.onClick.AddListener(OnHealClick);
            _levelUpButton.onClick.AddListener(OnLevelUpClick);
        }
        private void OnDisable()
        {
            _damageButton.onClick.RemoveListener(OnDamageClick);
            _healButton.onClick.RemoveListener(OnHealClick);
            _levelUpButton.onClick.RemoveListener(OnLevelUpClick);
        }

        private void OnDamageClick() => _playerMediator.DamagePlayer(Damage);
        private void OnHealClick() => _playerMediator.HealPlayer(Heal);
        private void OnLevelUpClick() => _playerMediator.LevelUpPlayer();
    }
}