using TMPro;
using UnityEngine;

namespace HW_3_Task_2
{
    public class SimpleCurrencyView : MonoBehaviour, ICurrencyView
    {
        [SerializeField] private TMP_Text _valueText;

        public void Show(int value)
        {
            _valueText.text = value.ToString();
        }
    }
}