public class ChecklistGoal : Goal
{
    private int DesiredAmount { get; set; }
    private int CurrentCount { get; set; }

    public ChecklistGoal(string goalName, int value, int desiredAmount)
        : base(goalName, "ChecklistGoal", value)
    {
        DesiredAmount = desiredAmount;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= DesiredAmount)
        {
            Completed = true;
            Console.WriteLine($"{GoalName} completed {CurrentCount}/{DesiredAmount} times! Goal Completed!");
        }
        else
        {
            Console.WriteLine($"{GoalName} completed {CurrentCount}/{DesiredAmount} times.");
        }
    }

    public bool IsComplete()
    {
        return Completed || CurrentCount >= DesiredAmount;
    }
}
