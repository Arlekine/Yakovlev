using System;
using UnityEngine;

namespace HW_1.Task2
{
    /// <summary>
    /// � ����� ����� ����� ������� ������������?
    /// � ������� ����� �������� ������ ����������� �����, �� ����� �� �� �������� ���������.
    /// </summary>
    public class WeaponSwitcher : MonoBehaviour
    {
        private ShootingControl _shootingControl;
        private IWeapon[] _weapons;
        private KeyCode[] _weaponKeys;

        public void Init(ShootingControl shootingControl, IWeapon[] weapons, KeyCode[] weaponKeys)
        {
            if (weapons.Length != weaponKeys.Length)
                throw new ArgumentException($"Amount of {nameof(weapons)} and amount of {nameof(weaponKeys)} should be the same.");

            _shootingControl = shootingControl;
            _weapons = weapons;
            _weaponKeys = weaponKeys;
        }

        private void Update()
        {
            for (int i = 0; i < _weaponKeys.Length; i++)
            {
                if (Input.GetKeyDown(_weaponKeys[i]))
                {
                    _shootingControl.SetWeapon(_weapons[i]);
                    print($"Weapon switched to {i}");
                }
            }
        }
    }
}