namespace HW_1.Task2
{
    public interface IAmmunition
    {
        bool CanSpend(int amountToSpend);
        void Spend(int amountToSpend);
    }
}