using BudgetApp.Logic;

var app = new App(GetCatagoryName, GetItemName, GetCatagoryBudget, GetItemPrice, GetCatagoryType);
app.Run();












static decimal GetCatagoryBudget()
{
    Console.Write("Enter your total budget: ");
    string input = Console.ReadLine() ?? "0";
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
    string input = Console.ReadLine() ?? "";
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
    string input = Console.ReadLine() ?? "0";
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
    string input = Console.ReadLine() ?? "";
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
    string? input = Console.ReadLine();
    if (input?.ToLower() == "y")
    {
        return true;
    }
    else if (input?.ToLower() == "n")
    {
        return false;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
        return GetCatagoryType();
    }
}
