using System;
using UnityEngine;

namespace HW_2_1.Task_2
{
    [Serializable]
    public class ProcessConfig
    {
        [Min(0.1f)][SerializeField] private float _pauseBetweenWorkSteps = 1f;
        [Range(1f, 10f)][SerializeField] private float _workDuration = 10f;
        [SerializeField] private string _processMessage;

        public float PauseBetweenWorkSteps => _pauseBetweenWorkSteps;
        public float WorkDuration => _workDuration;
        public string ProcessMessage => _processMessage;
    }
}