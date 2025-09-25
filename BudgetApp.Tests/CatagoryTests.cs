namespace BudgetApp.Tests;

using BudgetApp.Logic;
using FluentAssertions;
public class CatagoryTests
{
    [Fact]
    public void CatagoryIsNotNull()
    {
        Category catagory = new("Groceries",100, true);
                catagory.Should().NotBeNull();
    }

    [Fact]
    public void CatagoryNameIsSetOnCreation()
    {
        Category catagory = new("Groceries", 100, true);
        catagory.Name.Should().Be("Groceries");
    }

    [Fact]
    public void CatagoryRemainingShouldEqualBudgetOnCreation()
    {
        Category catagory = new("Groceries", 100, true);
        catagory.Remaining.Should().Be(100);
    }

    [Fact]
    public void CatagorySpentIsZeroOnCreation()
    {
        Category catagory = new("Groceries", 100, true);
        catagory.Spent.Should().Be(0);
    }
    
    [Fact]
    public void CatagoryBudgetIsSetOnCreation()
    {
        Category catagory = new("Groceries", 100, true);
        catagory.Budget.Should().Be(100);
    }

    [Fact]
    public void CatagorySpentIsUpdatedWhenItemAdded()
    {
        Category catagory = new("Groceries", 100, true);
        Item item = new("Test Item", 25);
        catagory.AddItem(item);
        catagory.Spent.Should().Be(25);
    }

    [Fact]
    public void CatagoryRemainingIsUpdatedWhenItemAdded()
    {
        Category catagory = new("Groceries", 100, true);
        Item item = new("Test Item", 25);
        catagory.AddItem(item);
        catagory.Remaining.Should().Be(75);
    }

    [Fact]
    public void CatagoryBudgetCannotBeNegative()
    {
        Category catagory = new("Groceries", -100, true);
        catagory.Budget.Should().Be(100);
    }

    [Fact]
    public void IsFoodCatagoryIsSetOnCreation()
    {
        Category catagory = new("Groceries", 100, true);
        catagory.IsFoodCatagory.Should().BeTrue();
    }

    [Fact]
    public void ItemsListIsEmptyOnCreation()
    {
        Category catagory = new("Groceries", 100, true);
        catagory.Items.Should().BeEmpty();
    }

    [Fact]
    public void ItemsListContainsItemAfterAdding()
    {
        Category catagory = new("Groceries", 100, true);
        Item item = new("Test Item", 25);
        catagory.AddItem(item);
        catagory.Items.Should().Contain(item);
    }
}
