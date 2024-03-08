using UnityEngine;

namespace HW_3_Task_2
{
    public class CurrencyShowingPanel : MonoBehaviour
    {
        [SerializeField] private Transform _iconsParent;

        public void Init(ICurrencyFactory factory, Coins coins, Energy energy)
        {
            factory.CreateCoinsView(coins, _iconsParent);
            factory.CreateEnergyView(energy, _iconsParent);
        }
    }
}