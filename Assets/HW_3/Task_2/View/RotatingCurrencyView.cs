using TMPro;
using UnityEngine;

namespace HW_3_Task_2
{
    public class RotatingCurrencyView : MonoBehaviour, ICurrencyView
    {
        private static Vector3 RotationAxis = new Vector3(0f, 0f, 1f);

        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private RectTransform _rotatingPart;

        [Space]
        [SerializeField] private float _rotationSpeed;

        public void Show(int value)
        {
            _valueText.text = value.ToString();
        }

        private void Update()
        {
            _rotatingPart.Rotate(RotationAxis, _rotationSpeed);
        }
    }
}