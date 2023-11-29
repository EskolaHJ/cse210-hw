using System.Collections.Generic;

public class BudgetManager
{
    private List<Income> Incomes;
    private List<Expense> Expenses;
    private decimal TotalBalance;

    public BudgetManager()
    {
        Incomes = new List<Income>();
        Expenses = new List<Expense>();
        TotalBalance = 0;
    }

    public void AddIncome(Income income)
    {
        Incomes.Add(income);
        TotalBalance += income.Amount;
    }

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
        TotalBalance -= expense.Amount;
    }

    public decimal GetTotalBalance()
    {
        return TotalBalance;
    }
    public List<Income> GetAllIncomes()
    {
        return new List<Income>(Incomes);
    }

    public List<Expense> GetAllExpenses()
    {
        return new List<Expense>(Expenses);
    }
    // Additional methods for managing budgets could be added here.
    // For example, methods to remove or modify existing income/expense records,
    // methods to get reports based on categories or dates, etc.
}
