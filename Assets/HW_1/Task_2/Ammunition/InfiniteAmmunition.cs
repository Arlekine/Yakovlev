using UnityEngine;

namespace HW_1.Task2
{
    public class InfiniteAmmunition : IAmmunition
    {
        public bool CanSpend(int amountToSpend) => true;
        public void Spend(int amountToSpend)
        {
            Debug.Log($"Infinite ammo used: ∞");
        }
    }
}