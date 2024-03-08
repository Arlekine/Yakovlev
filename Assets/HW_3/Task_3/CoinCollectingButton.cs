using UnityEngine;
using UnityEngine.UI;

namespace HW_3.Task_3
{
    public class CoinCollectingButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Canvas _canvas;

        private Coin _targetCoin;

        public void Init(Coin targetCoin, Camera camera)
        {
            _targetCoin = targetCoin;
            _canvas.worldCamera = camera;
        }

        private void OnEnable() => _button.onClick.AddListener(CollectCoin);
        private void OnDisable() => _button.onClick.RemoveListener(CollectCoin);

        private void CollectCoin()
        {
            _targetCoin.Collect();
            Destroy(gameObject);
        }
    }
}