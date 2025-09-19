namespace BudgetApp.Logic;
public class Catagory
{
    List<Item> items;
    private int Budget { get; set; }
    
    public Catagory(int budget)
    {
               items = new();
        Budget = budget;
    }
}
