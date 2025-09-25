using BudgetApp.Logic;

public class Budget
{
    public decimal TotalBudget { get; init; }
    public List<Category> Categories { get; }
    public decimal TotalSpent => Categories.Sum(category => category.Spent);
    public decimal RemainingBudget => TotalBudget - TotalSpent;
    public Budget(decimal totalBudget)
    {
        Categories = new();
        TotalBudget = totalBudget;
    }

    public void AddCategory(Category catagoryToAdd)
    {
        Categories.Add(catagoryToAdd);
    }

    public void RemoveCategory(Category catagoryToRemove)
    {
        Categories.Remove(catagoryToRemove);
    }
}