using System;

namespace HW_1.Task4
{
    public interface IWinCondition
    {
        event Action Won;
        event Action Lost;
    }
}