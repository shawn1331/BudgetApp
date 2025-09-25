using BudgetApp.Logic;

public class Budget
{
    public decimal TotalBudget;
    public List<Catagory> BudgetCategories = new List<Catagory>();
    public decimal TotalSpent => BudgetCategories.Sum(category => category.Spent);
    public decimal RemainingBudget => TotalBudget - TotalSpent;
    public Budget(decimal totalBudget, List<Catagory> budgetCategories)
    {
        TotalBudget = totalBudget;
        BudgetCategories = budgetCategories;
    }

    public void AddCategory(Catagory catagoryToAdd)
    {
        BudgetCategories.Add(catagoryToAdd);
    }

    public void RemoveCategory(Catagory catagoryToRemove)
    {
        BudgetCategories.Remove(catagoryToRemove);
    }
}