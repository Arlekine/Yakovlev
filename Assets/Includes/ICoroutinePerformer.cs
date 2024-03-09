using System.Collections;
using UnityEngine;

public interface ICoroutinePerformer
{
    Coroutine StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(Coroutine coroutine);
}