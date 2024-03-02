using UnityEngine;

namespace HW_2_1.Task_2
{
    public class Worker : MonoBehaviour, ICoroutinePerformer
    {
        [SerializeField] private NavMeshMover _navMeshMover;
        [SerializeField] private WorkerContext _workerContext;
        [SerializeField] private WorkerConfig _workerConfig;

        private WorkerStateMachine _stateMachine;

        public IMover Mover => _navMeshMover;
        public WorkerContext WorkerContext => _workerContext;
        public WorkerConfig WorkerConfig => _workerConfig;

        private void Start()
        {
            _stateMachine = new WorkerStateMachine(this);
        }
    }
}