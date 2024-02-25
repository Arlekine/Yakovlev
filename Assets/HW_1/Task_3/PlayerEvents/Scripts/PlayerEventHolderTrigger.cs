using System;
using UnityEngine;

namespace HW_1.Task3
{
    public class PlayerEventHolderTrigger : MonoBehaviour, IPlayerEventHolder
    {
        [SerializeField] private PlayerEvent _eventType;

        public event Action<PlayerEvent> Triggered;

        public void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                Triggered?.Invoke(_eventType);
            }
        }
    }
}