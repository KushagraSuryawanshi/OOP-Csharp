using NUnit.Framework;
using Program.cs;

namespace PlayerUnitTest
{
    [TestFixture]
    public class Tests
    {

        private Player _player;
        private Item _item1;
        private Item _item2;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Hero", "a brave adventurer");
            _item1 = new Item(new string[] { "sword" }, "Bronze Sword", "A shiny bronze sword.");
            _item2 = new Item(new string[] { "shield" }, "Iron Shield", "A sturdy iron shield.");
            _player.Inventory.Put(_item1);
            _player.Inventory.Put(_item2);
        }

        [Test]
        public void PlayerIdentifiesAsMeAndInventory()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void PlayerLocatesItemInInventory()
        {
            GameObject foundItem = _player.Locate("sword");
            Assert.AreEqual(_item1, foundItem);
            Assert.IsTrue(_player.Inventory.HasItem("sword"));
        }

        [Test]
        public void PlayerLocatesItself()
        {
            GameObject foundPlayer = _player.Locate("me");
            Assert.AreEqual(_player, foundPlayer);

            foundPlayer = _player.Locate("inventory");
            Assert.AreEqual(_player, foundPlayer);
        }

        [Test]
        public void PlayerFailsToLocateNonExistentItem()
        {
            GameObject foundItem = _player.Locate("nonexistentitem");
            Assert.IsNull(foundItem);
        }

        [Test]
        public void PlayerFullDescriptionIsCorrect()
        {
            string expectedDescription = "You are Hero, a brave adventurer. You are carrying:\n\ta Bronze Sword (sword)\n\ta Iron Shield (shield)";
            Assert.AreEqual(expectedDescription, _player.FullDescription);
        }
    }
}