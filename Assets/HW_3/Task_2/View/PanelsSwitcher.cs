using UnityEngine;
using UnityEngine.UI;

namespace HW_3_Task_2
{
    public class PanelsSwitcher : MonoBehaviour
    {
        [SerializeField] private CurrencyShowingPanel _simplePanel;
        [SerializeField] private CurrencyShowingPanel _rotatingPanel;

        [Space]
        [SerializeField] private Button _switchToSimplePanel;
        [SerializeField] private Button _switchToRotatingPanel;

        private void Start()
        {
            Switch(true);
        }

        private void OnEnable()
        {
            _switchToSimplePanel.onClick.AddListener(SwitchToSimple);
            _switchToRotatingPanel.onClick.AddListener(SwitchToRotating);
        }

        private void OnDisable()
        {
            _switchToSimplePanel.onClick.RemoveListener(SwitchToSimple);
            _switchToRotatingPanel.onClick.RemoveListener(SwitchToRotating);
        }

        private void SwitchToSimple()
        {
            Switch(true);
        }

        private void SwitchToRotating()
        {
            Switch(false);
        }

        private void Switch(bool isToSimple)
        {
            _simplePanel.gameObject.SetActive(isToSimple);
            _rotatingPanel.gameObject.SetActive(isToSimple == false);

            _switchToSimplePanel.gameObject.SetActive(isToSimple == false);
            _switchToRotatingPanel.gameObject.SetActive(isToSimple);
        }
    }
}