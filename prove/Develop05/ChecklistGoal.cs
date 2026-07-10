public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;

        if (_amountCompleted >= _targetAmount)
        {
            SetComplete(true);
        }
    }
    public ChecklistGoal(string name, string description, int points, int targetAmount, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _targetAmount = targetAmount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        int totalPoints = GetPoints();

        if (_amountCompleted == _targetAmount)
        {
            SetComplete(true);
            totalPoints += _bonus;
        }

        return totalPoints;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()}) Completed {_amountCompleted}/{_targetAmount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_amountCompleted},{_targetAmount},{_bonus}";
    }
}