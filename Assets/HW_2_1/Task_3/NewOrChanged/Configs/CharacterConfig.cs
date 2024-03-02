using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private SprintingStateConfig _sprintingStateConfig;

    [SerializeField] private AirborneStateConfig _airborneStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public SprintingStateConfig SprintingStateConfig => _sprintingStateConfig;

    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
}
