using System;

public class Expense : FinancialRecord
{
    public string Category { get; private set; }

    public Expense(decimal amount, DateTime date, string description, string category)
        : base(amount, date, description)
    {
        Category = category;
    }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Expense: {Amount}, Date: {Date}, Category: {Category}, Description: {Description}");
    }
}
