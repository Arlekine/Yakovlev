using HW_2_2.Task_2;
using UnityEngine;
using Zenject;

namespace HW_4.Task_2
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private HealthView _healthView;
        [SerializeField] private CharacterLevelView _levelView;
        [SerializeField] private ResetPanel _resetPanel;
        [SerializeField] private ControlPanel _controlPanel;


        public override void InstallBindings()
        {
            Container.Bind<HealthView>().FromInstance(_healthView).AsSingle();
            Container.Bind<CharacterLevelView>().FromInstance(_levelView).AsSingle();
            Container.Bind<ResetPanel>().FromInstance(_resetPanel).AsSingle();
            Container.Bind<ControlPanel>().FromInstance(_controlPanel).AsSingle();
        }
    }
}