using UnityEngine;

namespace HW_3_Task_2
{
    public class PrefabBasedCurrencyFactory<View> : ICurrencyFactory where View : Object, ICurrencyView
    {
        private View _coinsView;
        private View _energyView;

        public PrefabBasedCurrencyFactory(View coinsView, View energyView)
        {
            _coinsView = coinsView;
            _energyView = energyView;
        }

        public ICurrencyView CreateCoinsView(Coins coins, Transform parent)
        {
            var newView = Object.Instantiate(_coinsView, parent);
            newView.Show(coins.CurrentValue);
            return newView;
        }

        public ICurrencyView CreateEnergyView(Energy energy, Transform parent)
        {
            var newView = Object.Instantiate(_energyView, parent);
            newView.Show(energy.CurrentValue);
            return newView;
        }
    }
}