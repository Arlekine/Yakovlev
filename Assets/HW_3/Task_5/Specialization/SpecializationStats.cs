namespace HW_3.Task_5
{
    public class SpecializationStats : IStats
    {
        private IStats _stats;
        private Specialization _specialization;

        public SpecializationStats(IStats stats, Specialization specialization)
        {
            _stats = stats;
            _specialization = specialization;
        }

        public int Strength
        {
            get
            {
                var visitor = new SpecializationVisitor(_stats);
                visitor.Visit(_specialization);
                return visitor.Strength;
            }
        }

        public int Intellect
        {
            get
            {
                var visitor = new SpecializationVisitor(_stats);
                visitor.Visit(_specialization);
                return visitor.Intellect;
            }
        }

        public int Dexterity
        {
            get
            {
                var visitor = new SpecializationVisitor(_stats);
                visitor.Visit(_specialization);
                return visitor.Dexterity;
            }
        }

        private class SpecializationVisitor : ISpecializationVisitor, IStats
        {
            private IStats _stats;

            public SpecializationVisitor(IStats stats)
            {
                _stats = stats;

                Strength = _stats.Strength;
                Intellect = _stats.Intellect;
                Dexterity = _stats.Dexterity;
            }

            public int Strength { get; private set; }
            public int Intellect { get; private set; }
            public int Dexterity { get; private set; }

            public void Visit(Specialization specialization) => Visit((dynamic)specialization);

            public void Visit(Barbarian specialization)
            {
                Strength += 4;
                Intellect -= 2;
            }

            public void Visit(Wizard specialization)
            {
                Intellect += 2;
            }

            public void Visit(Thief specialization)
            {
                Dexterity *= 2;
                Intellect /= 2;
                Strength /= 2;
            }
        }
    }
}