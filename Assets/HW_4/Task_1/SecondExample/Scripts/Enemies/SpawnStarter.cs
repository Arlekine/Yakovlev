using UnityEngine;
using Zenject;

public class SpawnStarter : MonoBehaviour
{
    private EnemySpawner _spawner;

    [Inject]
    private void Construct(EnemySpawner enemySpawner)
    {
        _spawner = enemySpawner;
    }

    private void Start()
    {
        _spawner.StartWork();
    }
}
