namespace BeehiveManagementSystem
{
    internal interface IWorker
    {
        string Job { get; }
        void WorkTheNextShift();

    }

}
