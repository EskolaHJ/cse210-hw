public abstract class Goal
{
    public string GoalName { get; protected set; }
    public string GoalType { get; protected set; }
    protected int Value { get; set; }
    protected bool Completed { get; set; }

    protected Goal(string goalName, string goalType, int value)
    {
        GoalName = goalName;
        GoalType = goalType;
        Value = value;
        Completed = false;
    }

    public abstract void RecordEvent();

    public bool IsCompleted()
    {
        return Completed;
    }
}
