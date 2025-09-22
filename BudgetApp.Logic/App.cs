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
        Console.WriteLine("Welcome to the Budget App!");
        decimal totalBudget = GetCatagoryBudget();
        List<Catagory> catagories = new();
        while (true)
        {
            Console.Write("Do you want to add a catagory? (y/n): ");
            string? addCatagoryInput = Console.ReadLine();
            if (addCatagoryInput?.ToLower() != "y")
                break;
            string catagoryName = GetCatagoryName();
            Console.Write("Is this a food catagory? (y/n): ");
            string? isFoodInput = Console.ReadLine();
            bool isFoodCatagory = isFoodInput?.ToLower() == "y";
            decimal catagoryBudget = GetCatagoryBudget();
            Catagory catagory = new(catagoryName, catagoryBudget, isFoodCatagory);
            while (true)
            {
                Console.Write("Do you want to add an item to this catagory? (y/n): ");
                string? addItemInput = Console.ReadLine();
                if (addItemInput?.ToLower() != "y")
                    break;
                string itemName = GetItemName();
                decimal itemPrice = GetItemPrice();
                Item item = new(itemName, itemPrice);
                catagory.AddItem(item);
            }
            catagories.Add(catagory);
        }
        Console.WriteLine("\nBudget Summary:");
        Console.WriteLine($"Total Budget: {totalBudget:C}");
        decimal totalSpent = 0;
        foreach (var catagory in catagories)
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
}