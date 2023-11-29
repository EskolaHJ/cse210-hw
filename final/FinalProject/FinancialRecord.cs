using System;

public abstract class FinancialRecord
{
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public bool IsNew { get; set; }  // Flag to indicate if the record is new

    protected FinancialRecord(decimal amount, DateTime date, string description)
    {
        Amount = amount;
        Date = date;
        Description = description;
        IsNew = true;  // By default, records are new
    }

    public abstract void DisplayInformation();
}
