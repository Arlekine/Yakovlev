using UnityEngine;

namespace HW_3_Task_2
{
    public interface ICurrencyFactory
    {
        ICurrencyView CreateCoinsView(Coins coins, Transform parent);
        ICurrencyView CreateEnergyView(Energy energy, Transform parent);
    }
}