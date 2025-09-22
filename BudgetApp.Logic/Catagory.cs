namespace BudgetApp.Logic;
public class Catagory
{
    public const decimal FOOD_TAX_RATE = 0.07M;
    public const decimal NON_FOOD_TAX_RATE = 0.19M;
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

    public Catagory(string name, decimal budget, bool isFoodCatagory)
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
