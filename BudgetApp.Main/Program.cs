using BudgetApp.Logic;

var app = new App(GetCatagoryName, GetItemName, GetCatagoryBudget, GetItemPrice,
    GetCatagoryType, GetUserMenuSelection, GetMoneyToBudgetTotal, CreateNewCategory, PrintSummaryTable,
    Navigation);

app.Run(app);













static int GetUserMenuSelection()
{
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add a new catagory");
    Console.WriteLine("2. View summary table");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice (1-3): ");
    string? input = Console.ReadLine();
    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
    {
        return choice;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
        return GetUserMenuSelection();
    }
}
static decimal GetCatagoryBudget()
{
    Console.Write(Environment.NewLine + "Enter your total budget for this catagory: ");
    string? input = Console.ReadLine();
    if (decimal.TryParse(input, out decimal budget))
    {
        return budget;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        return GetCatagoryBudget();
    }
}

static string GetCatagoryName()
{
    Console.Write("Enter catagory name: ");
    string? input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        return input;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid catagory name.");
        return GetCatagoryName();
    }
}

static decimal GetItemPrice()
{
    Console.Write("Enter item price: ");
    string? input = Console.ReadLine();
    if (decimal.TryParse(input, out decimal price))
    {
        return price;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        return GetItemPrice();
    }
}

static string GetItemName()
{
    Console.Write("Enter item name: ");
    string? input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        return input;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid item name.");
        return GetItemName();
    }
}

static bool GetCatagoryType()
{
    Console.Write("Is this a food catagory? (y/n): ");
    char input = Console.ReadKey().KeyChar;
    if (input == 'y')
    {
        return true;
    }
    else if (input == 'n')
    {
        return false;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
        return GetCatagoryType();
    }
}

static void CreateNewCategory(App app)
{
    string catagoryName = GetCatagoryName();
    bool isFoodCatagory = GetCatagoryType();
    decimal catagoryBudget = GetCatagoryBudget();
    Category catagory = new(catagoryName, catagoryBudget, isFoodCatagory);
   app?.Budget?.Categories.Add(catagory);
    Console.WriteLine($"Great! {catagory.Name} was created.     ");
}

decimal GetMoneyToBudgetTotal()
{
    Console.WriteLine("What is the total amount you need to budget?");
    string? totalToBudgetUserReponse = Console.ReadLine();
    if (decimal.TryParse(totalToBudgetUserReponse, out decimal totalToBudget) && totalToBudget > 0)
    {
        return totalToBudget;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number greater than 0.");
        return GetMoneyToBudgetTotal();
    }
}

static void PrintSummaryTable(App app)
{
    Console.WriteLine("Numbers in parentheses indicate negative values (overspent)");
    Console.WriteLine();
    Console.WriteLine($"Monthly Income: {app?.Budget?.TotalBudget:C}");
    Console.WriteLine($"Total Allocated: {app?.Budget?.TotalSpent:C}");
    Console.WriteLine($"Unallocated: {app?.Budget?.RemainingBudget:C}");
    Console.WriteLine($"Total Spent: {app?.Budget?.TotalSpent:C}");
    Console.WriteLine($"Remaining Income: {app?.Budget?.RemainingBudget:C}");
    Console.WriteLine();

    Console.WriteLine($"{"Category",-20} {"Budget",15} {"Spent",15} {"Remaining",15}");
    Console.WriteLine(new string('=', 70));

    foreach (var category in app?.Budget?.Categories)
    {
        Console.WriteLine($"{category.Name,-20} {category.Budget,15:C} {category.Spent,15:C} {category.Remaining,15:C}-Overspent");

        if (category.Items.Count > 0)
        {
            Console.WriteLine($"{"",-5} {"Item",-25} {"Price",15}");
            foreach (var item in category.Items)
            {
                Console.WriteLine($"{"",-5} {item.Name,-25} {item.Price,15:C}");
            }
        }

        Console.WriteLine(new string('-', 70));
    }

    decimal totalBudget = app.Budget.Categories.Sum(c => c.Budget);
    decimal totalSpent = app.Budget.Categories.Sum(c => c.Spent);
    decimal totalRemaining = app.Budget.Categories.Sum(c => c.Remaining);

    Console.WriteLine($"{"TOTAL",-20} {totalBudget,15:C} {totalSpent,15:C} {totalRemaining,15:C}");
    Console.WriteLine(new string('=', 70));
}

static bool Navigation(App app)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[1] Create a new category");
    Console.WriteLine("[2] Add a transaction (add item to category)");
    Console.WriteLine("[3] View a summary of your catagories & budget");
    Console.WriteLine("[4] exit");
    string? userResponse = Console.ReadLine();
    if (userResponse == "1")
    {
        CreateNewCategory(app);
        return Navigation(app);
    }
    else if (userResponse == "2")
    {
        Category category = ChooseCategory(app);
        app.AddItemToCategory(category);
;        return Navigation(app);
    }
    else if (userResponse == "3")
    {
        PrintSummaryTable(app);
        return Navigation(app);
    }
    else if (userResponse == "4")
    {
        Console.WriteLine("Bye");
        return true;
    }
    else
    {
        Console.WriteLine("Invalid response. Please try again.");
        return Navigation(app);
    }
}

static Category ChooseCategory(App app)
{
    if (app?.Budget?.Categories.Count == 0)
    {
        Console.WriteLine("You need to add a category before adding items");
        CreateNewCategory(app);
        return ChooseCategory(app);
    }
    else
    {
        Console.WriteLine("Which category would you like to add an item?");
        for (int index = 0; index < app?.Budget?.Categories.Count; index++)
        {
            Console.WriteLine($"[{index + 1}] {app?.Budget?.Categories[index].Name}");
        }
        string? userResponse = Console.ReadLine();
        try
        {
            return app?.Budget?.Categories[Int32.Parse(userResponse) - 1];
        }
        catch
        {
            Console.WriteLine("Invalid response. Please try again.");
        }
    }
    return ChooseCategory(app);
}