namespace BudgetApp.Tests;

using BudgetApp.Logic;
using FluentAssertions;
public class ItemTests
{
	[Fact]
	public void ItemIsNotNullOnCreation()
	{
		Item item = new("Test Item", 25);
		item.Should().NotBeNull();
    }

	[Fact]
	public void ItemNameIsSetOnCreation()
	{
		Item item = new("Test Item", 25);
		item.Name.Should().Be("Test Item");
    }

	[Fact]
	public void ItemPriceIsSetOnCreation()
	{
		Item item = new("Test Item", 25);
		item.Price.Should().Be(25);
    }
}
