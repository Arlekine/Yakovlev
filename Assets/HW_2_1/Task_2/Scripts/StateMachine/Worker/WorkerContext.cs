using System;
using UnityEngine;

namespace HW_2_1.Task_2
{
    [Serializable]
    public class WorkerContext
    {
        [SerializeField] private Transform _workPoint;
        [SerializeField] private Transform _homePoint;

        public Transform WorkPoint => _workPoint;
        public Transform HomePoint => _homePoint;
    }
}