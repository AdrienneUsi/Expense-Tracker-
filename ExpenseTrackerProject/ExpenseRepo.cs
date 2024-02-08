using System;
using System.Data;
using ExpenseTrackerProject.Models;
using Dapper;

namespace ExpenseTrackerProject
{
    public class ExpenseRepo : IExpenseRepo
    {
        private readonly IDbConnection _conn;

        public ExpenseRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _conn.Query<Expense>("SELECT * FROM expenses;");
        }

        public Expense GetExpense(int id)
        {
            return _conn.QuerySingle<Expense>("SELECT * FROM expenses WHERE expense_id = @id", new { id = id });
        }


        public void UpdateExpense(Expense expense)
        {
            _conn.Execute("UPDATE expenses SET category_name = @Category_name, amount = @Amount WHERE expense_id = @id",
             new { category_name = expense.Category_name, amount = expense.Amount, id = expense.Expense_ID });
        }

        public void InsertExpense(Expense expenseToInsert)
        {
            _conn.Execute("INSERT INTO expenses (category, amount, expense_id) VALUES (@category, @amount, @expense_id);",
                new { Category = expenseToInsert.Category_name, Amount = expenseToInsert.Amount, Expense_id = expenseToInsert.Expense_ID });


        }

        public void DeleteExpense(Expense expense)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE Expense_ID = @id;", new { id = expense. Expense_ID });
            _conn.Execute("DELETE FROM Amount WHERE Expense_ID = @id;", new { id = expense.Expense_ID });
            _conn.Execute("DELETE FROM Expense WHERE Expense_ID = @id;", new { id = expense.Expense_ID});
        }
    }

}



