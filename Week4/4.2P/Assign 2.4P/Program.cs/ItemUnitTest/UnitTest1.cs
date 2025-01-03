using NUnit.Framework;
using Program.cs;

namespace ItemUnitTest
{
    [TestFixture]
    public class ItemTests
    {
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "sword", "weapon" }, "bronze sword", "A sturdy bronze sword.");
        }

        [Test]
        public void ItemIsIdentifiableByAnyId()
        {
            Assert.IsTrue(_item.AreYou("sword"));
            Assert.IsTrue(_item.AreYou("weapon"));
            Assert.IsFalse(_item.AreYou("shield"));
        }

        [Test]
        public void ItemShortDescriptionIsCorrect()
        {
            string expected = "a bronze sword (sword)";
            Assert.AreEqual(expected, _item.ShortDescription);
        }

        [Test]
        public void ItemFullDescriptionIsCorrect()
        {
            string expected = "A sturdy bronze sword.";
            Assert.AreEqual(expected, _item.FullDescription);
        }

        [Test]
        public void PrivilegeEscalationReturnsCorrectFirstId()
        {
            _item.PrivilegeEscalation("9447");
            string expected = "Class 1-6-EN310-WED-10:30";
            Assert.AreEqual(expected, _item.FirstId);
        }
       
    }
}