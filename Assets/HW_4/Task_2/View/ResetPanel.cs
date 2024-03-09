using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HW_2_2.Task_2
{
    public class ResetPanel : MonoBehaviour
    {
        [SerializeField] private Button _resetButton;

        public event Action ResetClicked;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        private void OnEnable() => _resetButton.onClick.AddListener(OnRestartClick);
        private void OnDisable() => _resetButton.onClick.RemoveListener(OnRestartClick);

        private void OnRestartClick() => ResetClicked?.Invoke();
    }
}