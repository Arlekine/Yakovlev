using UnityEngine;

namespace HW_2_1.Task_2
{
    public abstract class MovingState : IState
    {
        protected IStateSwitcher _stateSwitcher;
        protected IMover _mover;

        public MovingState(IStateSwitcher stateSwitcher, IMover mover)
        {
            _stateSwitcher = stateSwitcher;
            _mover = mover;
        }

        public void Enter()
        {
            _mover.MoveToPoint(GetDestinationPoint(), OnDestinationReached);
        }

        protected abstract Vector3 GetDestinationPoint();
        protected abstract void OnDestinationReached();
    }
}