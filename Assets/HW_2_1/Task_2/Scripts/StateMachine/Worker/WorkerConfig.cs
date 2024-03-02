using UnityEngine;

namespace HW_2_1.Task_2
{
    [CreateAssetMenu(menuName = "HW_2_1/Task_2/WorkerConfig", fileName = "WorkerConfig")]
    public class WorkerConfig : ScriptableObject
    {
        [SerializeField] private ProcessConfig _workConfig;
        [SerializeField] private ProcessConfig _restConfig;

        public ProcessConfig WorkConfig => _workConfig;
        public ProcessConfig RestConfig => _restConfig;
    }
}