using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW_1.Task2
{
    /// <summary>
    /// Еще не конца уверен, как обходиться с IDisposable в какой момент их диспозить. Что думаешь насчет такого подхода через Dispose в OnDestroy у корне?
    /// Я создаю разные BulletFactory, так как по задумке штуки, вроде ShootPoint тоже должны лежать там.
    /// Может стоило все это сосредоточить в Weapon, раз оно так называется, а то сейчас этои скорее Shooter.
    ///
    /// Также конечно штуки вроде WeaponSwitcher и ShootingContorl не обязательно делать монобехами - им просто нужен Update, но это не физические сущности, можно было бы их выделить в отдельные интерфейсы (типо IUpdateSystem) и крутить здесь (или лучше в специальной сущности)
    /// Но чет решил просто монобехами обойтись.
    /// </summary>
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private WeaponSwitcher _weaponSwitcher;
        [SerializeField] private ShootingControl _shootingControl;

        [Space]
        [SerializeField] private int _firstWeaponMaxAmmo = 30;
        [SerializeField] private int _thirdWeaponMaxAmmo = 50;

        [Space]
        [SerializeField] private int _weapon3BulletsInShot;
        [SerializeField] private float _weapon3PauseBetweenShots;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Start()
        {
            var bulletFactory1 = new SimpleBulletFactory();
            var bulletFactory2 = new SimpleBulletFactory();
            var bulletFactory3 = new SimpleBulletFactory();

            var ammunition1 = new FiniteAmmunition(_firstWeaponMaxAmmo);
            var ammunition2 = new InfiniteAmmunition();
            var ammunition3 = new FiniteAmmunition(_thirdWeaponMaxAmmo);

            var weapons = new IWeapon[3];

            weapons[0] = new SingleShotWeapon(ammunition1, bulletFactory1);
            weapons[1] = new SingleShotWeapon(ammunition2, bulletFactory2);
            weapons[2] = new MultishotWeapon(ammunition3, bulletFactory3, _weapon3BulletsInShot,
                _weapon3PauseBetweenShots, this);

            var weaponKeyCodes = new KeyCode[3];

            weaponKeyCodes[0] = KeyCode.Alpha1;
            weaponKeyCodes[1] = KeyCode.Alpha2;
            weaponKeyCodes[2] = KeyCode.Alpha3;

            _shootingControl.SetWeapon(weapons[0]);
            _weaponSwitcher.Init(_shootingControl, weapons, weaponKeyCodes);
        }
    }
}