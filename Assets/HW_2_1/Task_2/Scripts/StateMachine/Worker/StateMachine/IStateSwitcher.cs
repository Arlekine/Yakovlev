using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HW_2_1.Task_2
{
    public interface IStateSwitcher
    {
        void SwitchState<State>() where State : IState;
    }
}
