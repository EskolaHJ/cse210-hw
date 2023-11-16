public class EternalGoal : Goal
{
    private int RecordCount { get; set; }

    public EternalGoal(string goalName, int value)
        : base(goalName, "EternalGoal", value)
    {
        RecordCount = 0;
    }

    public override void RecordEvent()
    {
        RecordCount++;
        Console.WriteLine($"{GoalName} recorded {RecordCount} times. Gained {Value} points.");
    }
}
