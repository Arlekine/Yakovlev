using UnityEngine;

public class GlobalCoroutinePerformer : MonoBehaviour, ICoroutinePerformer
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}