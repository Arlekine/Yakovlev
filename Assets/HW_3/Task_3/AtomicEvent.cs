using System;

namespace HW_3.Task_3
{
    public sealed class AtomicEvent
    {
        private event Action onEvent;

        public void Invoke()
        {
            this.onEvent?.Invoke();
        }

        public void Subscribe(Action action)
        {
            this.onEvent += action;
        }

        public void Unsubscribe(Action action)
        {
            this.onEvent -= action;
        }
    }
}