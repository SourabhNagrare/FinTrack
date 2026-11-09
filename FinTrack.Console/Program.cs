using System;


bool isTrue = true;
List<int> expenses = new List<int>();

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
            expenses.Add(amount);
            System.Console.WriteLine("Expenses added successfully.");            
            break;

        case 2:
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses added yet!");
            }
            else
            {
                int totalExpenses = 0;
                foreach (int i in expenses)
                {
                    Console.WriteLine($"Expense: {i}");
                    totalExpenses += i;
                }

                Console.WriteLine("---------------------");
                Console.WriteLine($"Total Expenses: {totalExpenses}");
                Console.ReadLine();
            }
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