namespace BudgetApp.Logic;
public class Item
{
    public string Name { get; private set; }
    public decimal Price { get; init; }
    public int Quantity { get; private set; }

    public Item(string name, decimal price, int quantity = 1)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString() => $"{Name}: {Price:C}";
}
