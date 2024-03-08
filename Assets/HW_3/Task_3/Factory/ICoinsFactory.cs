using UnityEngine;

namespace HW_3.Task_3
{
    public interface ICoinsFactory
    {
        Coin CreateCoin(Transform parent, Vector3 position);
    }
}