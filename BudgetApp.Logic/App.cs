using System.ComponentModel;

namespace BudgetApp.Logic;

public class App
{
    public delegate string GetCatagoryNameDelegate();
    public delegate string GetItemNameDelegate();
    public delegate decimal GetCatagoryBudgetDelegate();
    public delegate decimal GetItemPriceDelegate();
    public delegate bool GetCatagoryTypeDelegate();
    public delegate int GetUserMenuSelectionDelegate();
    public delegate decimal GetTotalMoneyToBudgetDelegate();
    public delegate void CreateNewCategoryDelegate(App app);
    public delegate void PrintSummaryTableDelegate(App app);
    public delegate bool NavigationDelegate(App app);

    private readonly GetCatagoryBudgetDelegate GetCategoryBudget;
    private readonly GetItemPriceDelegate GetItemPrice;
    private readonly GetCatagoryNameDelegate GetCategoryName;
    private readonly GetItemNameDelegate GetItemName;
    private readonly GetCatagoryTypeDelegate GetCategoryType;
    private readonly GetUserMenuSelectionDelegate GetUserMenuSelection;
    private readonly GetTotalMoneyToBudgetDelegate GetTotalMoneyToBudget;
    private readonly CreateNewCategoryDelegate CreateNewCategory;
    private readonly PrintSummaryTableDelegate PrintSummaryTable;
    private readonly NavigationDelegate Navigation;

    public Budget? Budget { get; private set; }

    public App(GetCatagoryNameDelegate getCatagoryName, GetItemNameDelegate getItemName,
                      GetCatagoryBudgetDelegate getCatagoryBudget, GetItemPriceDelegate getItemPrice,
                      GetCatagoryTypeDelegate getCatagoryType, GetUserMenuSelectionDelegate getUserMenuSelection,
                      GetTotalMoneyToBudgetDelegate getTotalMoneyToBudget, CreateNewCategoryDelegate createNewCatagory,
                      PrintSummaryTableDelegate printSummaryTable, NavigationDelegate navigation)
    {
        Budget = null;
        GetItemName = getItemName;
        GetCategoryBudget = getCatagoryBudget;
        GetItemPrice = getItemPrice;
        GetCategoryName = getCatagoryName;
        GetCategoryType = getCatagoryType;
        GetUserMenuSelection = getUserMenuSelection;
        GetTotalMoneyToBudget = getTotalMoneyToBudget;
        CreateNewCategory = createNewCatagory;
        PrintSummaryTable = printSummaryTable;
        Navigation = navigation;
    }

    public void Run(App app)
    {
        Console.WriteLine(@"Welcome to the Budget App!
===============================================================");
        bool exit = false;
        while (!exit)
        {
            if (Budget == null)
            {
                decimal moneyToBudget = GetTotalMoneyToBudget();
                Budget = new(moneyToBudget);
            }
            exit = Navigation(app);
        }
    }

    public void AddItemToCategory(Category category)
    {
        string itemName = GetItemName();
        decimal itemPrice = GetItemPrice();
        Item item = new(itemName, itemPrice);
        category.AddItem(item);
    }

    //void ViewSummary(Budget budget)
    //{
    //    Console.WriteLine("\nBudget Summary:");
    //    Console.WriteLine($"Total Budget: {budget.TotalBudget:C}");
    //    decimal totalSpent = 0;
    //    foreach (var catagory in budget.Categories)
    //    {
    //        Console.WriteLine($"\nCatagory: {catagory.Name}");
    //        Console.WriteLine($"  Budget: {catagory.Budget:C}");
    //        Console.WriteLine($"  Spent: {catagory.Spent:C}");
    //        Console.WriteLine($"  Remaining: {catagory.Remaining:C}");
    //        totalSpent += catagory.Spent;
    //        if (catagory.Items.Count > 0)
    //        {
    //            Console.WriteLine("  Items:");
    //            foreach (var item in catagory.Items)
    //            {
    //                Console.WriteLine($"    - {item}");
    //            }
    //        }
    //    }
    //}
}