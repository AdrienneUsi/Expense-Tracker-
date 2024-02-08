using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTrackerProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTrackerProject.Controllers
{
    public class ExpenseController : Controller


    {
        private readonly IExpenseRepo _data;

        public ExpenseController(IExpenseRepo data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            var expenses = _data.GetAllExpenses();
            return View(expenses);
        }

        public IActionResult ViewExpense(int id)
        {
            var expenses = _data.GetExpense(id);
            return View(expenses);
        }

        public IActionResult UpdateExpense(int id)
        {
            Expense exp = _data.GetExpense(id);
            if (exp == null)
            {
                return View("ExpenseNotFound");
            }
            return View(exp);

           
        }
       
        public IActionResult UpdateExpenseToDatabase(Expense expense)
        {
            _data.UpdateExpense(expense);

            return RedirectToAction("ViewExpense", new { id = expense.Expense_ID });
        }

        public IActionResult InsertExpense(Expense expenseToInsert)
        {
           
            return View(expenseToInsert);
        }

        public IActionResult InsertExpenseToDatabase(Expense expenseToInsert)
        {
            _data.InsertExpense(expenseToInsert);
            return RedirectToAction("Index");
        }
    }


}

