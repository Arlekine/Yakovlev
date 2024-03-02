using System.Collections;
using UnityEngine;

namespace HW_2_1.Task_2
{
    public abstract class ProcessState : IState
    {
        private ICoroutinePerformer _coroutinePerformer;
        protected IStateSwitcher _stateSwitcher;

        protected ProcessState(IStateSwitcher stateSwitcher, ICoroutinePerformer coroutinePerformer)
        {
            _stateSwitcher = stateSwitcher;
            _coroutinePerformer = coroutinePerformer;
        }

        public void Enter()
        {
            _coroutinePerformer.StartCoroutine(ProcessRoutine());
        }

        protected abstract float GetWorkStepTime();
        protected abstract float GetWorkDuration();
        protected abstract void OnProcessStep();
        protected abstract void OnCompleted();

        private IEnumerator ProcessRoutine()
        {
            var processTime = 0f;

            while (processTime < GetWorkDuration())
            {
                yield return new WaitForSeconds(GetWorkStepTime());
                OnProcessStep();
                processTime += GetWorkStepTime();
            }

            OnCompleted();
        }
    }
}