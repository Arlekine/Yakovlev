using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawnerConfig _config;
    [SerializeField] private SpawnPointsHolder _pointsHolder;

    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<EnemySpawnerConfig>().FromInstance(_config).AsSingle();
        Container.Bind<SpawnPointsHolder>().FromInstance(_pointsHolder).AsSingle();
        Container.Bind<EnemySpawner>().AsSingle();
    }
}
