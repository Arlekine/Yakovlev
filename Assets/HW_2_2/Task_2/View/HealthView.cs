using UnityEngine;
using UnityEngine.UI;

namespace HW_2_2.Task_2
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetValues(int currentHealth, int maxHealth)
        {
            _slider.maxValue = maxHealth;
            _slider.value = currentHealth;
        }
    }
}