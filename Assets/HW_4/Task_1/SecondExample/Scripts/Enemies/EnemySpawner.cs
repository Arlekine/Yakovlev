using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner
{
    private EnemySpawnerConfig _enemySpawnerConfig;
    private IReadOnlyList<Transform> _spawnPoints;
    private EnemyFactory _enemyFactory;
    private ICoroutinePerformer _coroutinePerformer;

    private Coroutine _spawn;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, EnemySpawnerConfig config, ICoroutinePerformer coroutinePerformer, SpawnPointsHolder pointsHolder)
    {
        _enemyFactory = enemyFactory;
        _enemySpawnerConfig = config;
        _coroutinePerformer = coroutinePerformer;
        _spawnPoints = pointsHolder.Points;
    }

    public void StartWork()
    {
        StopWork();

        _spawn = _coroutinePerformer.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _coroutinePerformer.StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            yield return new WaitForSeconds(_enemySpawnerConfig.SpawnCooldown);
        }
    }
}