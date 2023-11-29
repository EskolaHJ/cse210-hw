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
        if (income.IsNew)
        {
            TotalBalance += income.Amount;
        }
    }

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
        if (expense.IsNew)
        {
            TotalBalance -= expense.Amount;
        }
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
}
