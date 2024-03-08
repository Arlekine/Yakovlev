using System;
using UnityEngine;

namespace HW_3.Task_3
{
    public interface IPointsHolder
    {
        bool HasFreePoints();
        Vector3 GetAndOccupyRandomPoint(AtomicEvent freeingCondition);
    }
}