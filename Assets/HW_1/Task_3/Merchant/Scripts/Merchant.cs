using UnityEngine;

namespace HW_1.Task3
{
    public abstract class Merchant : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                TradeWithPlayer(player);
            }
        }

        protected abstract void TradeWithPlayer(PlayerController player);
    }
}