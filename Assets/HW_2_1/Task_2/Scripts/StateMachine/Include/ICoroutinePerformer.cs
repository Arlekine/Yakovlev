using System.Collections;
using UnityEngine;

namespace HW_2_1.Task_2
{
    public interface ICoroutinePerformer
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}