using System;
using UnityEngine;

namespace HW_2_1.Task_2
{
    public interface IMover
    {
        void MoveToPoint(Vector3 point, Action onReached);
    }
}