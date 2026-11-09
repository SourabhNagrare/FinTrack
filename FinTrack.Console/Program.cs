using System;


bool isTrue = true;
List<Transaction> expenses = new List<Transaction>();

while (isTrue)
{
    System.Console.WriteLine("---Fintrack Menu---");
    System.Console.WriteLine("Select from the options below");
    System.Console.WriteLine("Option 1: Add Expense");
    System.Console.WriteLine("Option 2: View Expense");
    System.Console.WriteLine("Option 3: Exit.");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter the amount: ");
            int amount = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the Category: ");
            string category = Console.ReadLine();

            // Object Creation
            Transaction newTx = new Transaction();
            newTx.Amount = amount;
            newTx.Category = category;
            newTx.Date = DateTime.Now; // This will fetch the current Date/Time

            expenses.Add(newTx);


            System.Console.WriteLine("Expenses added successfully.");
            break;

        case 2:
            ViewExpenses(expenses);
            break;

        case 3:
            System.Console.WriteLine("Exiting app, GoodBye!");
            isTrue = false;
            break;

        default:
            System.Console.WriteLine("Enter a valid option number!!");
            break;
    }
}

static void ViewExpenses(List<Transaction> expenses)
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("No expenses added yet!");
    }
    else
    {
        int totalExpenses = 0;
        foreach (Transaction i in expenses)
        {
            Console.WriteLine($"Amount: {i.Amount} | Category : {i.Category} | Date : {i.Date.ToShortDateString()}");
            totalExpenses += i.Amount;
        }

        Console.WriteLine("---------------------");
        Console.WriteLine($"Total Expenses: {totalExpenses}");
        Console.ReadLine();
    }
}

public class Transaction
{
    public int Amount {get; set;}
    public string Category {get; set;}
    public DateTime Date {get; set;}
}