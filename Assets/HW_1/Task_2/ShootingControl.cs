using UnityEngine;

namespace HW_1.Task2
{
    public class ShootingControl : MonoBehaviour
    {
        private IWeapon _currentWeapon;

        public void SetWeapon(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _currentWeapon.Shoot();
        }
    }
}