using System;
namespace ExpenseTrackerProject.Models
{
    public class Expense
    {


        public int Expense_ID { get; set; }

        public string Category_name { get; set; }

        public string Amount { get; set; }

        public DateTime Date_Of_Expense { get; set; }

        public string Description { get; set; }

        public string Payment_Method { get; set; }

        public IEnumerable<Category> Categories { get; set; }






    }
}



