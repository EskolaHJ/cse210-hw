public class SimpleGoal : Goal
{
    private int BonusPoints { get; set; }

    public SimpleGoal(string goalName, int value, int bonusPoints)
        : base(goalName, "SimpleGoal", value)
    {
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        Completed = true;
        Console.WriteLine($"{GoalName} completed! Gained {Value + BonusPoints} points.");
    }
}
