namespace HW_3.Task_5
{
    public class Character
    {
        private IStats _stats;

        public Character(IStats stats)
        {
            _stats = stats;
        }

        public IStats Stats => _stats;
    }
}