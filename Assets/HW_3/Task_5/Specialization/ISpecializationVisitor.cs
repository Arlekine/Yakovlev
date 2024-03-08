namespace HW_3.Task_5
{
    public interface ISpecializationVisitor
    {
        void Visit(Specialization specialization);
        void Visit(Barbarian specialization);
        void Visit(Wizard specialization);
        void Visit(Thief specialization);
    }
}