public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            SetComplete(true);
            return GetPoints();
        }

        return 0;
    }

    public override string GetDetailsString()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_completed}";
    }
}