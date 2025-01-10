using NUnit.Framework;
using Program.cs;

namespace LookCommandUnitTests
{
    [TestFixture]
    public class LookCommandTests
    {
        private Player _player;
        private LookCommand _lookCommand;
        private Bag _smallBag;
        private Item _gem;
        private Bag _bag;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Hero", "A brave hero");
            _lookCommand = new LookCommand();
            _gem = new Item(new[] { "gem" }, "beautiful, sparkling gem", "A gem that sparkles brilliantly.");
            _smallBag = new Bag(new[] { "small_bag" }, "small bag", "A small bag has enough space for a laptop.");
            _bag = new Bag(new[] { "bag" }, "bag", "A bag has enough space for traveling.");

            // Adding items to player and bag
            _player.Inventory.Put(_gem);
            _player.Inventory.Put(_smallBag);
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_gem);
        }

        [Test]
        public void LookAtMe_ReturnsPlayerDescription()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "inventory" });
            Assert.AreEqual("You are Hero, A brave hero. You are carrying:\n\ta beautiful, sparkling gem (gem)\n\ta small bag (small_bag)\n\ta bag (bag)", result);
        }

        [Test]
        public void LookAtGem_ReturnsGemDescription()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem" });
            Assert.AreEqual("A gem that sparkles brilliantly.", result);
        }

        [Test]
        public void LookAtUnk_ReturnsCannotFindGem()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "ruby" });
            Assert.AreEqual("I can't find the ruby", result);
        }

        [Test]
        public void LookAtGemInMe_ReturnsGemDescription()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "inventory" });
            Assert.AreEqual("A gem that sparkles brilliantly.", result);
        }

        [Test]
        public void LookAtGemInBag_ReturnsGemDescription()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual("A gem that sparkles brilliantly.", result);
        }

        [Test]
        public void LookAtGemInNoBag_ReturnsCannotFindBag()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "nonexistent_bag" });
            Assert.AreEqual("I can't find the nonexistent_bag", result);
        }

        [Test]
        public void LookAtNoGemInBag_ReturnsCannotFindGem()
        {
            // Remove the gem from the bag first
            _bag.Inventory.Take("gem");
            string result = _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual("I can't find the gem in the bag", result);
        }

        [Test]
        public void LookAtInvalidCommands_ReturnsErrorMessages()
        {
            string result = _lookCommand.Execute(_player, new[] { "look", "around" });
            Assert.AreEqual("I don’t know how to look like that", result);

            result = _lookCommand.Execute(_player, new[] { "hello", "1048094447" });
            Assert.AreEqual("I don’t know how to look like that", result);

            // Test looking at an item that does not exist
            result = _lookCommand.Execute(_player, new[] { "look", "at", "nonexistent_item" });
            Assert.AreEqual("I can't find the nonexistent_item", result);

            // Test looking at an item in a container that does not exist
            result = _lookCommand.Execute(_player, new[] { "look", "at", "nonexistent_item", "in", "nonexistent_container" });
            Assert.AreEqual("I can't find the nonexistent_container", result);
        }
    }
}
