using UnityEngine;

namespace HW_1.Task2
{
    public class SingleShotWeapon : IWeapon
    {
        private IBulletFactory _bulletFactory;

        public SingleShotWeapon(IAmmunition ammunition, IBulletFactory bulletFactory)
        {
            Ammunition = ammunition;
            _bulletFactory = bulletFactory;
        }

        public IAmmunition Ammunition { get; private set; }

        public bool Shoot()
        {
            if (Ammunition.CanSpend(1))
            {
                Ammunition.Spend(1);
                _bulletFactory.CreateBullet();
                return true;
            }

            Debug.Log($"Out of ammo!");
            return false;
        }
    }
}