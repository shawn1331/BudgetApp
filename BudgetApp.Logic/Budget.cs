using BudgetApp.Logic;

public class Budget
{
    public decimal TotalBudget;
    public List<Catagory> BudgetCategories = new List<Catagory>();
    public decimal TotalSpent => BudgetCategories.Sum(category => category.Spent);
    public decimal RemainingBudget => TotalBudget - TotalSpent;
    Budget(decimal totalBudget, List<Catagory> budgetCategories)
    {
        TotalBudget = totalBudget;
        BudgetCategories = budgetCategories;
    }

    public void AddCategory()
    {

    }

    public void RemoveCategory()
    { 
        
    }
}