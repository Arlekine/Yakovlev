using System;
using UnityEngine;

namespace HW_1.Task2
{
    public class FiniteAmmunition : IAmmunition
    {
        private int _maxAmmo;
        private int _currentAmmo;

        public FiniteAmmunition(int maxAmmo)
        {
            _maxAmmo = maxAmmo;

            _currentAmmo = _maxAmmo;
        }

        public bool CanSpend(int amountToSpend) => _currentAmmo - amountToSpend >= 0;

        public void Spend(int amountToSpend)
        {
            if (CanSpend(amountToSpend) == false)
                throw new ArgumentException("Not enough ammo");

            _currentAmmo -= amountToSpend;

            //в этом месте предпалогалось бы выкидывать событие на обновление UI
            Debug.Log($"Finite ammo used: {_currentAmmo}/{_maxAmmo}");
        }
    }
}