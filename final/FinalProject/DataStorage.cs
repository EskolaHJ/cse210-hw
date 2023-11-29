using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DataStorage
{
    private const string FilePath = "FinancialRecords.txt";

    public void SaveRecords(IEnumerable<FinancialRecord> records)
    {
        using (StreamWriter file = new StreamWriter(FilePath))
        {
            foreach (var record in records)
            {
                if (record is Income income)
                {
                    file.WriteLine($"Income,{income.Amount},{income.Date:yyyy-MM-dd},{income.Source},{income.Description}");
                }
                else if (record is Expense expense)
                {
                    file.WriteLine($"Expense,{expense.Amount},{expense.Date:yyyy-MM-dd},{expense.Category},{expense.Description}");
                }
            }
        }
    }

    public List<FinancialRecord> LoadRecords()
    {
        var records = new List<FinancialRecord>();

        if (File.Exists(FilePath))
        {
            using (StreamReader file = new StreamReader(FilePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var fields = line.Split(',');
                    if (fields[0] == "Income")
                    {
                        records.Add(new Income(decimal.Parse(fields[1]), DateTime.Parse(fields[2]), fields[4], fields[3]));
                    }
                    else if (fields[0] == "Expense")
                    {
                        records.Add(new Expense(decimal.Parse(fields[1]), DateTime.Parse(fields[2]), fields[4], fields[3]));
                    }
                }
            }
        }

        return records;
    }
}
