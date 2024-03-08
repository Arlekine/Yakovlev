using UnityEngine;

namespace HW_3_Task_2
{
    public class CompositeRoot : MonoBehaviour
    {
        private const int StartCoins = 10;
        private const int StartEnergy = 100;

        [SerializeField] private SimpleCurrencyView _coinsSimpleView;
        [SerializeField] private SimpleCurrencyView _energySimpleView;

        [Space]
        [SerializeField] private RotatingCurrencyView _coinsRotatingView;
        [SerializeField] private RotatingCurrencyView _energyRotatingView;

        [Space]
        [SerializeField] private CurrencyShowingPanel _simplePanel;
        [SerializeField] private CurrencyShowingPanel _rotatingPanel;

        private void Start()
        {
            var coins = new Coins(StartCoins);
            var energy = new Energy(StartEnergy);

            var simpleFactory = new PrefabBasedCurrencyFactory<SimpleCurrencyView>(_coinsSimpleView, _energySimpleView);
            var rotatingFactory = new PrefabBasedCurrencyFactory<RotatingCurrencyView>(_coinsRotatingView, _energyRotatingView);

            _simplePanel.Init(simpleFactory, coins, energy);
            _rotatingPanel.Init(rotatingFactory, coins, energy);
        }
    }
}