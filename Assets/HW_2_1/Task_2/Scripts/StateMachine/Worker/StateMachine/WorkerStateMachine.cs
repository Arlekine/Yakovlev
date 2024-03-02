using System.Collections.Generic;
using System.Linq;

namespace HW_2_1.Task_2
{
    public class WorkerStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;

        public WorkerStateMachine(Worker worker)
        {
            _states = new List<IState>()
            {
                new MoveToWorkState(worker.WorkerContext, this, worker.Mover),
                new MoveToHomeState(worker.WorkerContext, this, worker.Mover),
                new RestState(worker.WorkerConfig, this, worker),
                new WorkState(worker.WorkerConfig, this, worker)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }


        public void SwitchState<State>() where State : IState
        {
            IState state = _states.FirstOrDefault(state => state is State);

            _currentState = state;
            _currentState.Enter();
        }
    }
}