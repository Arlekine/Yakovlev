namespace HW_3.Task_5
{
    public interface IPassiveAbilityVisitor
    {
        void Visit(PassiveAbility ability);
        void Visit(GreatStrength ability);
        void Visit(LowIntelligence ability);
        void Visit(UnlimitedDexterity ability);
    }
}