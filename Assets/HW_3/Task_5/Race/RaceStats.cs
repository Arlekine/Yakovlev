namespace HW_3.Task_5
{
    public class RaceStats : IStats
    {
        private IStats _stats;
        private Race _race;

        public RaceStats(IStats stats, Race race)
        {
            _stats = stats;
            _race = race; 
        }

        public int Strength
        {
            get
            {
                var visitor = new RaceVisitor(_stats);
                visitor.Visit(_race);
                return visitor.Strength;
            }
        }

        public int Intellect
        {
            get
            {
                var visitor = new RaceVisitor(_stats);
                visitor.Visit(_race);
                return visitor.Intellect;
            }
        }

        public int Dexterity
        {
            get
            {
                var visitor = new RaceVisitor(_stats);
                visitor.Visit(_race);
                return visitor.Dexterity;
            }
        }

        private class RaceVisitor : IRaceVisitor, IStats
        {
            private IStats _stats;

            public RaceVisitor(IStats stats)
            {
                _stats = stats;

                Strength = _stats.Strength;
                Intellect = _stats.Intellect;
                Dexterity = _stats.Dexterity;
            }

            public int Strength { get; private set; }
            public int Intellect { get; private set; }
            public int Dexterity { get; private set; }

            public void Visit(Race race) => Visit((dynamic)race);

            public void Visit(Orc race)
            {
                Strength += 10;
                Intellect += 2;
                Dexterity += 3;
            }

            public void Visit(Elf elf)
            {
                Strength += 4;
                Intellect += 4;
                Dexterity += 7;
            }

            public void Visit(Human human)
            {
                Strength += 5;
                Intellect += 5;
                Dexterity += 5;
            }
        }
    }
}