namespace HW_3.Task_5
{
    public class PassiveAbilityStats : IStats
    {
        private IStats _stats;
        private PassiveAbility _ability;

        public PassiveAbilityStats(IStats stats, PassiveAbility ability)
        {
            _stats = stats;
            _ability = ability;
        }

        public int Strength
        {
            get
            {
                var visitor = new PassiveAbilityVisitor(_stats);
                visitor.Visit(_ability);
                return visitor.Strength;
            }
        }

        public int Intellect
        {
            get
            {
                var visitor = new PassiveAbilityVisitor(_stats);
                visitor.Visit(_ability);
                return visitor.Intellect;
            }
        }

        public int Dexterity
        {
            get
            {
                var visitor = new PassiveAbilityVisitor(_stats);
                visitor.Visit(_ability);
                return visitor.Dexterity;
            }
        }

        private class PassiveAbilityVisitor : IPassiveAbilityVisitor, IStats
        {
            private IStats _stats;

            public PassiveAbilityVisitor(IStats stats)
            {
                _stats = stats;

                Strength = _stats.Strength;
                Intellect = _stats.Intellect;
                Dexterity = _stats.Dexterity;
            }

            public void Visit(PassiveAbility ability) => Visit((dynamic) ability);

            public void Visit(GreatStrength ability)
            {
                Strength += 4;
            }

            public void Visit(LowIntelligence ability)
            {
                Intellect /= 2;
            }

            public void Visit(UnlimitedDexterity ability)
            {
                Dexterity *= 2;
            }

            public int Strength { get; private set; }
            public int Intellect { get; private set; }
            public int Dexterity { get; private set; }
        }
    }
}