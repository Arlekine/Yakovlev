using System;
using System.Collections;
using UnityEngine;

namespace HW_1.Task2
{
    public class MultishotWeapon : IWeapon, IDisposable
    {
        private IBulletFactory _bulletFactory;
        private int _bulletsInShot;
        private float _pauseBetweenBullets;
        private MonoBehaviour _monoContext;

        private Coroutine _currentShotRoutine;

        public MultishotWeapon(IAmmunition ammunition, IBulletFactory bulletFactory,
            int bulletsInShot, float pauseBetweenBullets, MonoBehaviour monoContext)
        {
            Ammunition = ammunition;
            _bulletFactory = bulletFactory;
            _bulletsInShot = bulletsInShot;
            _pauseBetweenBullets = pauseBetweenBullets;
            _monoContext = monoContext;
        }

        public IAmmunition Ammunition { get; private set; }

        public bool Shoot()
        {
            if (Ammunition.CanSpend(_bulletsInShot))
            {
                _currentShotRoutine = _monoContext.StartCoroutine(ShotRoutine());
                return true;
            }

            Debug.Log($"Out of ammo!");
            return false;
        }

        private IEnumerator ShotRoutine()
        {
            for (int i = 0; i < _bulletsInShot; i++)
            {
                _bulletFactory.CreateBullet();
                Ammunition.Spend(1);
                yield return new WaitForSeconds(_pauseBetweenBullets);
            }
        }

        public void Dispose()
        {
            _monoContext?.StopCoroutine(_currentShotRoutine);
        }
    }
}