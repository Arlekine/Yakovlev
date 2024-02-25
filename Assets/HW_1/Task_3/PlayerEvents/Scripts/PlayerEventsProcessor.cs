using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HW_1.Task3
{
    public class PlayerEventsProcessor : IDisposable
    {
        private IEnumerable<IPlayerEventHolder> _initialEvent;

        private Transform _merchantsPoint;

        private DoNotTradeMerchant _doNotTradeMerchant;
        private FruitMerchant _fruitMerchant;
        private ArmorMerchant _armorMerchant;

        private Merchant _currentMerchant;

        public PlayerEventsProcessor(IEnumerable<IPlayerEventHolder> initialEvent, DoNotTradeMerchant doNotTradeMerchant, FruitMerchant fruitMerchant, ArmorMerchant armorMerchant, Transform merchantsPoint)
        {
            _initialEvent = initialEvent;
            _doNotTradeMerchant = doNotTradeMerchant;
            _fruitMerchant = fruitMerchant;
            _armorMerchant = armorMerchant;

            _merchantsPoint = merchantsPoint;

            _initialEvent = initialEvent;

            foreach (var playerEvent in _initialEvent)
            {
                playerEvent.Triggered += OnTriggered;
            }

            CreateMerchant(_doNotTradeMerchant);
        }

        public void Dispose()
        {
            foreach (var playerEvent in _initialEvent)
            {
                if (playerEvent != null)
                    playerEvent.Triggered -= OnTriggered;
            }
        }

        private void OnTriggered(PlayerEvent ev)
        {
            switch (ev)
            {
                case PlayerEvent.FruitFarm:
                    Debug.Log("Fruit farm visited!");
                    CreateMerchant(_fruitMerchant);
                    break;

                case PlayerEvent.CaveEntrance:
                    Debug.Log("Dungeon visited!");
                    CreateMerchant(_armorMerchant);
                    break;
            }
        }

        private void CreateMerchant(Merchant prefab)
        {
            if (_currentMerchant != null)
                Object.Destroy(_currentMerchant.gameObject);

            _currentMerchant = Object.Instantiate(prefab, _merchantsPoint);
        }
    }
}