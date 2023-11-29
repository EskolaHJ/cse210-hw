using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        BudgetManager manager = new BudgetManager();
        DataStorage storage = new DataStorage();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. Show Total Balance");
            Console.WriteLine("4. Save Records");
            Console.WriteLine("5. Load Records");
            Console.WriteLine("6. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddIncome(manager);
                    break;
                case "2":
                    AddExpense(manager);
                    break;
                case "3":
                    Console.WriteLine($"Total Balance: {manager.GetTotalBalance()}");
                    break;
                case "4":
                    SaveRecords(manager, storage);
                    break;
                case "5":
                    LoadRecords(manager, storage);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddIncome(BudgetManager manager)
    {
        try
        {
            Console.WriteLine("Enter amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter source:");
            string source = Console.ReadLine();
            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();

            Income income = new Income(amount, DateTime.Now, description, source);
            manager.AddIncome(income);
            Console.WriteLine("Income added successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format for amount. Please enter a valid number.");
        }
    }

    static void AddExpense(BudgetManager manager)
    {
        try
        {
            Console.WriteLine("Enter amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter category:");
            string category = Console.ReadLine();
            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();

            Expense expense = new Expense(amount, DateTime.Now, description, category);
            manager.AddExpense(expense);
            Console.WriteLine("Expense added successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format for amount. Please enter a valid number.");
        }
    }

    static void SaveRecords(BudgetManager manager, DataStorage storage)
    {
        var allRecords = new List<FinancialRecord>();
        allRecords.AddRange(manager.GetAllIncomes());
        allRecords.AddRange(manager.GetAllExpenses());
        storage.SaveRecords(allRecords);
        Console.WriteLine("Records saved to file.");
    }

    static void LoadRecords(BudgetManager manager, DataStorage storage)
    {
        var records = storage.LoadRecords();
        foreach (var record in records)
        {
            if (record is Income income)
            {
                manager.AddIncome(income);
            }
            else if (record is Expense expense)
            {
                manager.AddExpense(expense);
            }
        }
        Console.WriteLine("Records loaded from file.");
    }
}
