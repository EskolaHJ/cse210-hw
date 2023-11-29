using System;
using System.Collections.Generic;

public class ReportGenerator
{
    public void GenerateMonthlyReport(List<FinancialRecord> records)
    {
        foreach (var record in records)
        {
            record.DisplayInformation();
        }
    }
}
