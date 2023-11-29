using System;

public abstract class FinancialRecord
{
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }

    protected FinancialRecord(decimal amount, DateTime date, string description)
    {
        Amount = amount;
        Date = date;
        Description = description;
    }

    public abstract void DisplayInformation();
}
