using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private int _maxSpawnWeight = 100;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;
        private SpawnWeight _spawnWeight;

        private AddWeightVisitor _addWeightVisitor;
        private RemoveWeightVisitor _removeWeightVisitor;

        public event Action<Enemy> Notified;

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());

            _spawnWeight = new SpawnWeight(_maxSpawnWeight);
            _addWeightVisitor = new AddWeightVisitor(_spawnWeight);
            _removeWeightVisitor = new RemoveWeightVisitor(_spawnWeight);
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);

            _spawnWeight = null;
            _addWeightVisitor = null;
            _removeWeightVisitor = null;
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();    
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_spawnWeight.CanSpawn())
                {
                    Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                    enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                    enemy.Died += OnEnemyDied;

                    _addWeightVisitor.Visit(enemy);

                    _spawnedEnemies.Add(enemy);
                }
                
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            Notified?.Invoke(enemy);
            _removeWeightVisitor.Visit(enemy);
            _spawnedEnemies.Remove(enemy);
        }

        private class SpawnWeight
        {
            private int _currentWeight;
            private int _maxWeight;

            public SpawnWeight(int maxWeight)
            {
                _maxWeight = maxWeight;
            }

            public bool CanSpawn() => _maxWeight < _currentWeight;

            public void AddWeight(int weight)
            {
                if (CanSpawn() == false)
                    throw new ArgumentException($"Spawn weight is maxed");

                _currentWeight += weight;
            }

            public void RemoveWeight(int weight)
            {
                if (_currentWeight < weight)
                    throw new ArgumentException("Attempt to reduce weight below zero");

                _currentWeight -= weight;
            }
        }

        private class AddWeightVisitor : IEnemyVisitor
        {
            private SpawnWeight _weight;

            public AddWeightVisitor(SpawnWeight weight)
            {
                _weight = weight;
            }

            public void Visit(Ork ork) => _weight.AddWeight(20);

            public void Visit(Elf elf) => _weight.AddWeight(5);

            public void Visit(Human human) => _weight.AddWeight(10);

            public void Visit(Robot robot) => _weight.AddWeight(15);

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }

        private class RemoveWeightVisitor : IEnemyVisitor
        {
            private SpawnWeight _weight;

            public RemoveWeightVisitor(SpawnWeight weight)
            {
                _weight = weight;
            }

            public void Visit(Ork ork) => _weight.RemoveWeight(20);

            public void Visit(Elf elf) => _weight.RemoveWeight(5);

            public void Visit(Human human) => _weight.RemoveWeight(10);

            public void Visit(Robot robot) => _weight.RemoveWeight(15);

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);
        }
    }
}
