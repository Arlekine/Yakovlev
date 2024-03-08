using System.Linq;
using UnityEngine;

namespace HW_3.Task_3
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private CoinCollectingButton _coinCollectingButtonPrefab;

        [Space]
        [SerializeField] private Transform[] _coinsSpawnPoints;

        [Space]
        [SerializeField] private CoinsSpawnControl _spawnControl;

        [Space]
        [SerializeField] private Transform _coinsParent;

        private void Start()
        {
            var coinsFactory = new CoinsWithCollectingButtonFactory(_coinPrefab, _coinCollectingButtonPrefab, Camera.main);
            var points = _coinsSpawnPoints.Select(x => x.position);

            var pointsHolder = new SpawnPointsHolder(points);

            var coinsSpawner = new CoinsSpawner(_coinsParent, pointsHolder, coinsFactory);

            _spawnControl.Init(coinsSpawner);
        }
    }
}