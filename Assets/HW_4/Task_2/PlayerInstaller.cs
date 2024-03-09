using HW_2_2.Task_2;
using UnityEngine;
using Zenject;

namespace HW_4.Task_2
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private int _playerHealth = 100;
        [SerializeField] private int _playerStartLevel = 1;

        //Это так должно выглядеть?
        public override void InstallBindings()
        {
            var health = new Health(_playerHealth);
            var characterLevel = new CharacterLevel(_playerStartLevel);

            var player = new HW_2_2.Task_2.Player(health, characterLevel);

            Container.Bind<HW_2_2.Task_2.Player>().FromInstance(player).AsSingle();
        }
    }
}