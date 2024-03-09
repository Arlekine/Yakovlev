using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsConfig", menuName = "Player/StatsConfig")]
public class PlayerStatsConfig : ScriptableObject
{
    [SerializeField, Range(1, 150)] private int _maxHealth;

    public int MaxHealth => _maxHealth;
}
