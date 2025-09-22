namespace BudgetApp.Tests;

using BudgetApp.Logic;
using FluentAssertions;
public class CatagoryTests
{
    [Fact]
    public void CatagoryIsNotNull()
    {
        Catagory catagory = new("Groceries",100, true);
                catagory.Should().NotBeNull();
    }

    [Fact]
    public void CatagoryNameIsSetOnCreation()
    {
        Catagory catagory = new("Groceries", 100, true);
        catagory.Name.Should().Be("Groceries");
    }

    [Fact]
    public void CatagoryRemainingShouldEqualBudgetOnCreation()
    {
        Catagory catagory = new("Groceries", 100, true);
        catagory.Remaining.Should().Be(100);
    }

    [Fact]
    public void CatagorySpentIsZeroOnCreation()
    {
        Catagory catagory = new("Groceries", 100, true);
        catagory.Spent.Should().Be(0);
    }
    
    [Fact]
    public void CatagoryBudgetIsSetOnCreation()
    {
        Catagory catagory = new("Groceries", 100, true);
        catagory.Budget.Should().Be(100);
    }

    [Fact]
    public void CatagorySpentIsUpdatedWhenItemAdded()
    {
        Catagory catagory = new("Groceries", 100, true);
        Item item = new("Test Item", 25);
        catagory.AddItem(item);
        catagory.Spent.Should().Be(25);
    }

    [Fact]
    public void CatagoryRemainingIsUpdatedWhenItemAdded()
    {
        Catagory catagory = new("Groceries", 100, true);
        Item item = new("Test Item", 25);
        catagory.AddItem(item);
        catagory.Remaining.Should().Be(75);
    }

    [Fact]
    public void CatagoryBudgetCannotBeNegative()
    {
        Catagory catagory = new("Groceries", -100, true);
        catagory.Budget.Should().Be(100);
    }

    [Fact]
    public void IsFoodCatagoryIsSetOnCreation()
    {
        Catagory catagory = new("Groceries", 100, true);
        catagory.IsFoodCatagory.Should().BeTrue();
    }

    [Fact]
    public void ItemsListIsEmptyOnCreation()
    {
        Catagory catagory = new("Groceries", 100, true);
        catagory.Items.Should().BeEmpty();
    }

    [Fact]
    public void ItemsListContainsItemAfterAdding()
    {
        Catagory catagory = new("Groceries", 100, true);
        Item item = new("Test Item", 25);
        catagory.AddItem(item);
        catagory.Items.Should().Contain(item);
    }
}
