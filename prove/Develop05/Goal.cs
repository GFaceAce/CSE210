public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();

    public abstract string GetDetailsString();

    public abstract string GetStringRepresentation();

    public bool IsComplete()
    {
        return _isComplete;
    }

    protected void SetComplete(bool complete)
    {
        _isComplete = complete;
    }

    protected string GetName()
    {
        return _name;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }
}