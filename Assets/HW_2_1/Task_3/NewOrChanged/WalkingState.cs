public class WalkingState : GroundedState
{
    private WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsWalkInput() == false)
            StateSwitcher.SwitchState<RunningState>();
    }

    private bool IsWalkInput() => Input.Movement.Walk.IsPressed();
}