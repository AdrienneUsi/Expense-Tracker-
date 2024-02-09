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
            _conn.Execute("UPDATE expenses SET category_name = @category_name, amount = @amount, date_of_expense = @date_of_expense, description = @description, payment_method = @payment_method WHERE expense_id = @expense_id",
             new { category_name = expense.Category_name, amount = expense.Amount, date_of_expense = expense.Date_Of_Expense, description = expense.Description, payment_method = expense.Payment_Method, expense_id = expense.Expense_ID });
        }

        public void InsertExpense(Expense expenseToInsert)
        {
            _conn.Execute("INSERT INTO expenses (category_name, amount, date_of_expense, description, payment_method, expense_id) VALUES (@category, @amount, @date_of_expense, @description, @payment_method, @expense_id);",
                new { category = expenseToInsert.Category_name, amount = expenseToInsert.Amount, date_of_expense = expenseToInsert.Date_Of_Expense, description = expenseToInsert.Description, payment_method = expenseToInsert.Payment_Method, expense_id = expenseToInsert.Expense_ID});


        }

        public void DeleteExpense(Expense expense)
        {
           
            _conn.Execute("DELETE FROM expenses WHERE expense_id = @id;", new { id = expense.Expense_ID});
        }
    }

}



