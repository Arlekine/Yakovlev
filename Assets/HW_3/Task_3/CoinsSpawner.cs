using System;
using UnityEngine;

namespace HW_3.Task_3
{
    public class CoinsSpawner
    {
        private Transform _coinsParent;
        private SpawnPointsHolder _spawnPointsHolder;
        private ICoinsFactory _coinsFactory;

        public CoinsSpawner(Transform coinsParent, SpawnPointsHolder spawnPointsHolder, ICoinsFactory coinsFactory)
        {
            _coinsParent = coinsParent;
            _spawnPointsHolder = spawnPointsHolder;
            _coinsFactory = coinsFactory;
        }

        public bool CanSpawn() => _spawnPointsHolder.HasFreePoints();

        public void Spawn()
        {
            if (CanSpawn() == false)
                throw new Exception("Cant spawn new coin - no free points!");
            
            var coinCollectedEvent = new AtomicEvent();
            var spawnPoint = _spawnPointsHolder.GetAndOccupyRandomPoint(coinCollectedEvent);

            var coin = _coinsFactory.CreateCoin(_coinsParent, spawnPoint);

            coin.Collected += (c) => coinCollectedEvent.Invoke();
        }
    }
}