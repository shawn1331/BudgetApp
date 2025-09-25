using BudgetApp.Logic;

public class Budget
{
    public decimal TotalBudget;
    public List<Category> BudgetCategories = new List<Category>();
    public decimal TotalSpent => BudgetCategories.Sum(category => category.Spent);
    public decimal RemainingBudget => TotalBudget - TotalSpent;
    public Budget(decimal totalBudget, List<Category> budgetCategories)
    {
        TotalBudget = totalBudget;
        BudgetCategories = budgetCategories;
    }

    public void AddCategory(Category catagoryToAdd)
    {
        BudgetCategories.Add(catagoryToAdd);
    }

    public void RemoveCategory(Category catagoryToRemove)
    {
        BudgetCategories.Remove(catagoryToRemove);
    }
}