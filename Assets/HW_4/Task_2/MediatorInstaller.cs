using HW_2_2.Task_2;
using Zenject;

namespace HW_4.Task_2
{
    public class MediatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerMediator>().AsSingle().NonLazy();
        }
    }
}