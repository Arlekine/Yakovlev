using UnityEngine;
using Zenject;

public class GlobalsInstaller : MonoInstaller
{
    [SerializeField] private GlobalCoroutinePerformer _coroutinePerformer;

    public override void InstallBindings()
    {
        var performer = Container.InstantiatePrefabForComponent<GlobalCoroutinePerformer>(_coroutinePerformer, Vector3.one, Quaternion.identity, null);
        Container.Bind<ICoroutinePerformer>().FromInstance(performer).AsSingle();
    }
}