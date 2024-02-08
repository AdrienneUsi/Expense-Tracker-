using System;
using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject
{
    public interface IExpenseRepo
    {
        public IEnumerable<Expense> GetAllExpenses();

        public Expense GetExpense(int id);

        public void UpdateExpense(Expense expense);

        public void InsertExpense(Expense expenseToInsert);

        public void DeleteExpense(Expense expense);


    }
}
