using System;
using UnityEngine;

namespace HW_1.Task4
{
    public interface IBallPopper
    {
        event Action<Ball> BallPopped;
    }
}