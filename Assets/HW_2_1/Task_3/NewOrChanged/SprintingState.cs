public class SprintingState : GroundedState
{
    private SprintingStateConfig _config;

    public SprintingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.SprintingStateConfig;

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

        if (IsSprintInput() == false)
            StateSwitcher.SwitchState<RunningState>();
    }

    private bool IsSprintInput() => Input.Movement.Sprint.IsPressed();
}