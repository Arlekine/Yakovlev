using UnityEngine;

namespace HW_2_1.Task_2
{
    public class MoveToWorkState : MovingState
    {
        private WorkerContext _context;

        public MoveToWorkState(WorkerContext context, IStateSwitcher stateSwitcher, IMover mover) : base(stateSwitcher, mover)
            => _context = context;

        protected override Vector3 GetDestinationPoint() => _context.WorkPoint.position;

        protected override void OnDestinationReached() => _stateSwitcher.SwitchState<WorkState>();
    }
}