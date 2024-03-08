namespace HW_3.Task_5
{
    public interface IRaceVisitor
    {
        void Visit(Race race);
        void Visit(Orc race);
        void Visit(Elf race);
        void Visit(Human race);
    }
}