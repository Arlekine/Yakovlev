using UnityEngine;

namespace HW_2_1.Task_2
{
    public sealed class RestState : ProcessState
    {
        private ProcessConfig _processConfig;

        public RestState(WorkerConfig config, IStateSwitcher stateSwitcher, ICoroutinePerformer coroutinePerformer) : base(stateSwitcher, coroutinePerformer)
            => _processConfig = config.RestConfig;

        protected override float GetWorkStepTime() => _processConfig.PauseBetweenWorkSteps;
        protected override float GetWorkDuration() => _processConfig.WorkDuration;
        protected override void OnProcessStep() => Debug.Log(_processConfig.ProcessMessage);
        protected override void OnCompleted() => _stateSwitcher.SwitchState<MoveToWorkState>();
    }
}