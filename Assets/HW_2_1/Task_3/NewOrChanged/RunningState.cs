public class RunningState : GroundedState
{
    private RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

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

        if (IsSprintInput())
            StateSwitcher.SwitchState<SprintingState>();

        if (IsWalkInput())
            StateSwitcher.SwitchState<WalkingState>();
    }

    private bool IsSprintInput() => Input.Movement.Sprint.IsPressed();
    private bool IsWalkInput() => Input.Movement.Walk.IsPressed();
}