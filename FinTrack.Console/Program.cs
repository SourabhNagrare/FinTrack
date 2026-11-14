using System;
using System.IO;
using System.Text.Json;

bool isTrue = true;
List<Transaction> expenses = new List<Transaction>();

LoadData(expenses);
ArrayDemo();

while (isTrue)
{
    System.Console.WriteLine("---Fintrack Menu---");
    System.Console.WriteLine("Select from the options below");
    System.Console.WriteLine("Option 1: Add Expense");
    System.Console.WriteLine("Option 2: View Expense");
    System.Console.WriteLine("Option 3: Search Expense");
    System.Console.WriteLine("Option 4: Exit.");

    int choice = 0;
    try
    {
        choice = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number.. ");
        continue;
    }
    switch (choice)
    {
        case 1:
            int amount = 0;
            try
            {
                Console.WriteLine("Enter the amount: ");
                amount = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input!! please enter a valid number.");
                break;
            }


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
            Console.WriteLine("Enter the keyword you wanna search: ");
            string keyword = Console.ReadLine();
            var searchResults = expenses.Where(e => e.Category.ToLower().Contains(keyword.ToLower())).ToList();

            if(searchResults.Count > 0) 
            // why not (searchResult != null){} because [  expenses.Where(...).ToList() ] <- this creates a new list, and if no match is found then it returns an empty list whose count is 0, and 0 is not null so the if condition will always be true.
            {
                foreach(Transaction i in searchResults)
                {
                    Console.WriteLine($"Amount: {i.Amount} | Category : {i.Category} | Date : {i.Date.ToShortDateString()}");

                }
            }
            else
                {
                    Console.WriteLine("No matching record found.");
                }

            Console.ReadLine();
            break;


        case 4:
            SaveData(expenses);
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
        return; //stopped here.
    }
        // 1. To print the loop.
        foreach (Transaction i in expenses)
        {
            Console.WriteLine($"Amount: {i.Amount} | Category : {i.Category} | Date : {i.Date.ToShortDateString()}");
        }

        // 2. LINQ total

        int totalExpenses = expenses.Sum(item => item.Amount);

        // 3. LINQ category breakdown

        var categoryTotals = expenses.GroupBy(item => item.Category).ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

        // 4. Print total and dictionary

        Console.WriteLine("---------------------");
        Console.WriteLine($"Total Expenses: {totalExpenses}");

        foreach(var pair in categoryTotals)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        Console.ReadLine();

}


static void SaveData (List<Transaction> expenses)
{
    // List conversion to JSON text.
    string jsonString = JsonSerializer.Serialize(expenses);

    //Writing this text in the json file.
    File.WriteAllText("data.json", jsonString);

}

static void LoadData (List<Transaction> expenses)
{
    // To begin, first check if the file actually exists
    if (File.Exists("data.json"))
    {
        string jsonString = File.ReadAllText("data.json");

        // Converting the text back to the List<Transaction>
        List<Transaction> loadedExpenses = JsonSerializer.Deserialize<List<Transaction>>(jsonString);

        if(loadedExpenses != null)
        {
            expenses.AddRange(loadedExpenses);
        }
    } 
}


static void ArrayDemo()
{
    string[] Category = {"Food", "Travel", "shopping"};
    int[] Budget = {200, 500, 300};

    for(int a =  0; a < Category.Length; a++)
    {
        Console.WriteLine($"Category : {Category[a]}  |  Budget : {Budget[a]}");
    }
}


public class Transaction
{
    public int Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
}
