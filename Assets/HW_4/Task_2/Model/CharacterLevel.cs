using System;

namespace HW_2_2.Task_2
{
    public class CharacterLevel
    {
        private const int MinimalLevel = 1;

        private int _currentLevel;

        public CharacterLevel(int currentLevel)
        {
            if (currentLevel <= 0)
                throw new ArgumentException($"{nameof(currentLevel)} can't be less that {MinimalLevel}");

            _currentLevel = currentLevel;
        }

        public event Action<int> LevelChanged;
        
        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;
                LevelChanged?.Invoke(_currentLevel);
            }
        }

        public void IncreaseLevel()
        {
            CurrentLevel++;
        }

        public void Reset()
        {
            CurrentLevel = MinimalLevel;
        }
    }
}