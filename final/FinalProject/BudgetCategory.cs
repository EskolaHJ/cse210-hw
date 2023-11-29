public class BudgetCategory
{
    public string Name { get; private set; }
    public decimal MonthlyLimit { get; private set; }

    public BudgetCategory(string name, decimal monthlyLimit)
    {
        Name = name;
        MonthlyLimit = monthlyLimit;
    }

    public void UpdateMonthlyLimit(decimal newLimit)
    {
        MonthlyLimit = newLimit;
    }
}
