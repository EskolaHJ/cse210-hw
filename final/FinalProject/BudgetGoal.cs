using System;

public class BudgetGoal
{
    public decimal TargetAmount { get; private set; }
    public DateTime DueDate { get; private set; }
    public string CurrentStatus { get; private set; }

    public BudgetGoal(decimal targetAmount, DateTime dueDate)
    {
        TargetAmount = targetAmount;
        DueDate = dueDate;
        CurrentStatus = "Pending";
    }
}
