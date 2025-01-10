using NUnit.Framework;
using Program.cs;

namespace InventoryUnitTests
{
    [TestFixture]
    public class InventoryTests
    {
        private Inventory _inventory;
        private Item _item1;
        private Item _item2;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _item1 = new Item(new string[] { "sword" }, "Bronze Sword", "A shiny bronze sword.");
            _item2 = new Item(new string[] { "shield" }, "Iron Shield", "A sturdy iron shield.");
        }

        [Test]
        public void Put_AddsItemToInventory_ItemCanBeFound()
        {
            _inventory.Put(_item1);
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [Test]
        public void HasItem_ItemNotInInventory_ReturnsFalse()
        {
            Assert.IsFalse(_inventory.HasItem("hammer"));
        }

        [Test]
        public void Fetch_RemovesItemFromInventory_ReturnsItem()
        {
            _inventory.Put(_item1);
            GameObject fetchedItem = _inventory.Fetch("sword");
            Assert.IsNotNull(fetchedItem);
            Assert.AreEqual(_item1, fetchedItem);
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [Test]
        public void Take_RemovesItemFromInventory_ItemCanNoLongerBeFound()
        {
            _inventory.Put(_item1);
            GameObject takenItem = _inventory.Take("sword");
            Assert.IsNotNull(takenItem);
            Assert.AreEqual(_item1, takenItem);
            Assert.IsFalse(_inventory.HasItem("sword"));
        }

        [Test]
        public void ItemList_WithMultipleItems_ReturnsCorrectList()
        {
            _inventory.Put(_item1);
            _inventory.Put(_item2);
            string itemList = _inventory.ItemList;
            string expectedList = "\ta Bronze Sword (sword)\n\ta Iron Shield (shield)";
            Assert.AreEqual(expectedList, itemList);
        }
    }
}
