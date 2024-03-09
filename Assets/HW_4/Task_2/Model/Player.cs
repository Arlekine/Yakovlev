namespace HW_2_2.Task_2
{
    public class Player
    {
        private Health _health;
        private CharacterLevel _characterLevel;

        public Player(Health health, CharacterLevel characterLevel)
        {
            _health = health;
            _characterLevel = characterLevel;
        }

        public Health Health => _health;
        public CharacterLevel CharacterLevel => _characterLevel;

        public void Reset()
        {
            Health.Reset();
            CharacterLevel.Reset();
        }
    }
}