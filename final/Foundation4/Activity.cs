public class Activity
{
    private string _date;
    private double _minutes;
    public Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }
    protected string GetDate()
    {
        return _date;
    }
    protected double GetMinutes()
    {
        return _minutes;
    }
    public virtual double GetDistance()
    {
        return 0;
    }
    public virtual double GetSpeed()
    {
        return 0;
    }
    public virtual double GetPace()
    {
        return 0;
    }
    public string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min): Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace {GetPace():F1} min per mile";
    }
}