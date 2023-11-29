using System;

public class Income : FinancialRecord
{
    public string Source { get; private set; }

    public Income(decimal amount, DateTime date, string description, string source)
        : base(amount, date, description)
    {
        Source = source;
    }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Income: {Amount}, Date: {Date}, Source: {Source}, Description: {Description}");
    }
}
