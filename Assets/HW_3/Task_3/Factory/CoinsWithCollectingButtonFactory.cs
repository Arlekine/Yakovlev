using UnityEngine;

namespace HW_3.Task_3
{
    public class CoinsWithCollectingButtonFactory : ICoinsFactory
    {
        private Coin _prefab;
        private CoinCollectingButton _collectingButton;
        private Camera _eventCamera;

        public CoinsWithCollectingButtonFactory(Coin prefab, CoinCollectingButton collectingButton, Camera eventCamera)
        {
            _prefab = prefab;
            _collectingButton = collectingButton;
            _eventCamera = eventCamera;
        }

        public Coin CreateCoin(Transform parent, Vector3 position)
        {
            var coin = Object.Instantiate(_prefab, parent);
            var collectButton = Object.Instantiate(_collectingButton, parent);

            coin.transform.position = position;
            collectButton.transform.position = position;

            collectButton.Init(coin, _eventCamera);

            return coin;
        }
    }
}