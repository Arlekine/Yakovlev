using UnityEngine;

[CreateAssetMenu(menuName = "HW_4/Task_1/EnemySpawnerConfig", fileName = "EnemySpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField] private float _spawnCooldown;

    public float SpawnCooldown => _spawnCooldown;
}