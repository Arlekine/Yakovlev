using UnityEngine;

namespace HW_2_1.Task_2
{
    public class MoveToHomeState : MovingState
    {
        private WorkerContext _context;

        public MoveToHomeState(WorkerContext context, IStateSwitcher stateSwitcher, IMover mover) : base(stateSwitcher, mover)
            => _context = context;

        protected override Vector3 GetDestinationPoint() => _context.HomePoint.position;

        protected override void OnDestinationReached() => _stateSwitcher.SwitchState<RestState>();
    }
}