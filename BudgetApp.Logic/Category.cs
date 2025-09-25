namespace BudgetApp.Logic;
public class Category
{
    public const decimal FOOD_TAX_RATE = 0.03M;
    public const decimal NON_FOOD_TAX_RATE = 0.0635M;
    public bool IsFoodCatagory { get; init; }
    public string Name { get; private set; }
    public List<Item> Items { get; }
    public decimal Budget { get; init; }
    public decimal Spent
    {
        get
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            if (IsFoodCatagory)
                total += total * FOOD_TAX_RATE;
            else
                total += total * NON_FOOD_TAX_RATE;

            return total;
        }
    }

    public decimal Remaining
    {
        get
        {
            return Budget - Spent;
        }
    }

    public Category(string name, decimal budget, bool isFoodCatagory)
    {
        Items = new();
        Name = name;
        Budget = budget;
        IsFoodCatagory = isFoodCatagory;
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }
}
