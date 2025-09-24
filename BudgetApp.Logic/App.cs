using System.Runtime.CompilerServices;

namespace BudgetApp.Logic;

public class App
{
    public delegate string GetCatagoryNameDelegate();
    public delegate string GetItemNameDelegate();
    public delegate decimal GetCatagoryBudgetDelegate();
    public delegate decimal GetItemPriceDelegate();
    public delegate bool GetCatagoryTypeDelegate();

    private GetCatagoryBudgetDelegate GetCatagoryBudget;
    private GetItemPriceDelegate GetItemPrice;
    private GetCatagoryNameDelegate GetCatagoryName;
    private GetItemNameDelegate GetItemName;
    private GetCatagoryTypeDelegate GetCatagoryType;

    public App(GetCatagoryNameDelegate getCatagoryName, GetItemNameDelegate getItemName, GetCatagoryBudgetDelegate getCatagoryBudget, GetItemPriceDelegate getItemPrice, GetCatagoryTypeDelegate getCatagoryType)
    {
        GetItemName = getItemName;
        GetCatagoryBudget = getCatagoryBudget;
        GetItemPrice = getItemPrice;
        GetCatagoryName = getCatagoryName;
        GetCatagoryType = getCatagoryType;
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to the Budget App!");
            decimal moneyToBudget = GetTotalMoneyToBudget();
            List<Catagory> budgetCategories = new List<Catagory>();
            Budget budget = new Budget(moneyToBudget, budgetCategories);
            exit = Navigation(budget);
        }
    }
    bool Navigation(Budget budget)
    {
        Console.WriteLine("Now what would you like to do");
        Console.WriteLine("[1] Create a new category");
        Console.WriteLine("[2] Add a transaction (add item to category)");
        Console.WriteLine("[3] View a summary of your budget");
        Console.WriteLine("[4] exit");
        string? userResponse = Console.ReadLine();
        if (userResponse == "1")
        {
            CreateNewCategory(budget.BudgetCategories);
            return Navigation(budget);
        }
        else if (userResponse == "2")
        {
            Catagory category = ChooseCategory(budget.BudgetCategories);
            AddItemToCategory(category);
            return Navigation(budget);
        }
        else if (userResponse == "3")
        {
            ViewSummary(budget);
            return Navigation(budget);
        }
        else if (userResponse == "4")
        {
            Console.WriteLine("Bye");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid response. Please try again.");
            return Navigation(budget);
        }
    }

    void CreateNewCategory(List<Catagory> catagories)
    {
        Console.Write("Please enter the name of the new catagory: ");
        string catagoryName = GetCatagoryName();
        Console.Write("Is this a food catagory? (y/n): ");
        string? isFoodInput = Console.ReadLine();
        bool isFoodCatagory = isFoodInput?.ToLower() == "y";
        decimal catagoryBudget = GetCatagoryBudget();
        Catagory catagory = new(catagoryName, catagoryBudget, isFoodCatagory);
        catagories.Add(catagory);
        Console.WriteLine($"Great! {catagory.Name} is added to you budget");
    }

    void AddItemToCategory(Catagory category)
    {
        string itemName = GetItemName();
        decimal itemPrice = GetItemPrice();
        Item item = new(itemName, itemPrice);
        category.AddItem(item);
    }

    Catagory ChooseCategory(List<Catagory> catagories)
    {
        if (catagories.Count == 0)
        {
            Console.WriteLine("You need to add a category before adding items");
            CreateNewCategory(catagories);
            return ChooseCategory(catagories);
        }
        else
        {
            for (int index = 0; index < catagories.Count; index++)
            {
                Console.WriteLine($"[{index}] {catagories[index].Name}");
            }
            Console.WriteLine("To which category would you like to add an item?");
            string? userResponse = Console.ReadLine();
            try
            {
                return catagories[Int32.Parse(userResponse)];
            }
            catch
            {
                Console.WriteLine("Invalid response. Please try again.");
            }
        }
        return ChooseCategory(catagories);
    }

    void ViewSummary(Budget budget)
    {
        Console.WriteLine("\nBudget Summary:");
        Console.WriteLine($"Total Budget: {budget.TotalBudget:C}");
        decimal totalSpent = 0;
        foreach (var catagory in budget.BudgetCategories)
        {
            Console.WriteLine($"\nCatagory: {catagory.Name}");
            Console.WriteLine($"  Budget: {catagory.Budget:C}");
            Console.WriteLine($"  Spent: {catagory.Spent:C}");
            Console.WriteLine($"  Remaining: {catagory.Remaining:C}");
            totalSpent += catagory.Spent;
            if (catagory.Items.Count > 0)
            {
                Console.WriteLine("  Items:");
                foreach (var item in catagory.Items)
                {
                    Console.WriteLine($"    - {item}");
                }
            }
        }
    }

    decimal GetTotalMoneyToBudget()
    { 
        Console.WriteLine("What is the total amount you need to budget?");
        string? totalToBudgetUserReponse = Console.ReadLine();
        try
        {
            return decimal.Parse(totalToBudgetUserReponse);
        }
        catch
        {
            Console.WriteLine("Invald response. Please try again.");
            return GetTotalMoneyToBudget();
        }
    }
}