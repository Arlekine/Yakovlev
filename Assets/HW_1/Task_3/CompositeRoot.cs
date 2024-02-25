using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW_1.Task3
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private PlayerEventHolderTrigger[] _eventTriggers;
        [SerializeField] private Transform _merchantPoint;

        [Header("Merchants prefabs")]
        [SerializeField] private DoNotTradeMerchant _doNotTradeMerchantPrefab;
        [SerializeField] private FruitMerchant _fruitMerchant;
        [SerializeField] private ArmorMerchant _armorMerchant;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Start()
        {
            var eventsProcessor = new PlayerEventsProcessor(_eventTriggers, _doNotTradeMerchantPrefab, _fruitMerchant, _armorMerchant, _merchantPoint);
            _disposables.Add(eventsProcessor);
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}