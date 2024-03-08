namespace HW_3.Task_5
{
    public class BasicStats : IStats
    {
        private int _strength;
        private int _intellect;
        private int _dexterity;

        public BasicStats(int strength, int intellect, int dexterity)
        {
            _strength = strength;
            _intellect = intellect;
            _dexterity = dexterity;
        }

        public int Strength { get; }
        public int Intellect { get; }
        public int Dexterity { get; }
    }
}
