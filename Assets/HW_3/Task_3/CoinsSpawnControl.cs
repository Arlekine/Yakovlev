using UnityEngine;

namespace HW_3.Task_3
{
    public class CoinsSpawnControl : MonoBehaviour
    {
        private CoinsSpawner _coinsSpawner;

        public void Init(CoinsSpawner coinsSpawner)
        {
            _coinsSpawner = coinsSpawner;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_coinsSpawner.CanSpawn())
                    _coinsSpawner.Spawn();
                else
                    print("Cant spawn!");
            }
        }
    }
}