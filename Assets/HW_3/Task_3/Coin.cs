
using System;
using UnityEngine;

namespace HW_3.Task_3
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        public void Collect()
        {
            Collected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}