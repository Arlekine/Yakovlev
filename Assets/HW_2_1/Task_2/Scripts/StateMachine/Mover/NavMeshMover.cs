using System;
using UnityEngine;
using UnityEngine.AI;

namespace HW_2_1.Task_2
{
    public class NavMeshMover : MonoBehaviour, IMover
    {
        [SerializeField] private NavMeshAgent _agent;

        private bool _isMoving;
        private Action _currentReachAction;

        /// <summary>
        /// Не знаю какой exception юзать в этом случае
        /// </summary>
        /// <param name="point"></param>
        public void MoveToPoint(Vector3 point, Action onReached)
        {
            if (_isMoving)
                throw new Exception("Can't set new point to mover until current is reached.");

            _currentReachAction = onReached;
            _agent.isStopped = false;
            _agent.SetDestination(point);
            _isMoving = true;
        }

        private void Update()
        {
            if (_isMoving && _agent.remainingDistance <= _agent.stoppingDistance)
            {
                _isMoving = false;
                _agent.isStopped = true;
                _currentReachAction?.Invoke();
            }
        }
    }
}