using System;

namespace HW_3_Task_2
{
    public class Currency
    {
        private int _currentValue;

        public Currency(int currentValue)
        {
            _currentValue = currentValue;
        }

        public event Action<int> Changed;

        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                Changed?.Invoke(_currentValue);
            }
        }

        public void Add(int value)
        {
            if (value <= 0)
                throw new ArgumentException($"Adding value should be positive");

            _currentValue += value;
        }

        public void Spend(int value)
        {
            if (value <= 0)
                throw new ArgumentException($"Spending value should be positive");
            
            if (value > _currentValue)
                throw new ArgumentException($"Attempt to spend more than current value");

            _currentValue -= value;
        }
    }
}
