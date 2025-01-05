using NUnit.Framework;
using Program.cs;

namespace BagUnitTests
{
    [TestFixture]
    public class Tests
    {
        private Bag testBag;
        private Item testItem1;
        private Item testItem2;

        [SetUp]
        public void Setup()
        {
            testBag = new Bag(new string[] { "testbag" }, "a test bag", "A testing bag");
            testItem1 = new Item(new string[] { "pencil" }, "gold pencil", "A great pencil.");
            testItem2 = new Item(new string[] { "monitor" }, "nvidia monitor", "A very fast monitor.");
            testBag.Inventory.Put(testItem1);
            testBag.Inventory.Put(testItem2);
        }

        [Test]
        public void Locate_ShouldFindItemsInBag()
        {
            Assert.AreEqual(testItem1, testBag.Locate("pencil"));
            Assert.AreEqual(testItem2, testBag.Locate("monitor"));
        }

        [Test]
        public void Locate_ShouldReturnBagItselfForSelfReferences()
        {
            Assert.AreEqual(testBag, testBag.Locate("testbag"));
        }

        [Test]
        public void Locate_ShouldReturnNullForNonexistentItems()
        {
            Assert.AreEqual(null, testBag.Locate("car"));
        }

        [Test]
        public void FullDescription_ShouldReturnFormattedDescription()
        {
            string expectedDescription = "In the a test bag you can see:\n\ta gold pencil (pencil)\n\ta nvidia monitor (monitor)";
            string actualDescription = testBag.FullDescription;

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void Locate_ShouldFindNestedBagsAndItems()
        {
            Bag b1 = new Bag(new string[] {"bag1" }, "bag 1", "The first bag");
            Bag b2 = new Bag(new string[] {"bag2" }, "bag 2", "The second bag");
            Item itemInB1 = new Item(new string[] { "item1"}, "item in b1", "An item in bag 1");
            Item itemInB2 = new Item(new string[] {"item2" }, "item in b2", "An item in bag 2");

            b1.Inventory.Put(b2);
            b1.Inventory.Put(itemInB1);
            b2.Inventory.Put(itemInB2);

            Assert.AreEqual(b2, b1.Locate("bag2"));
            Assert.AreEqual(itemInB1, b1.Locate("item1"));
            Assert.AreEqual(null, b1.Locate("item2"));
        }

        [Test]
        public void Locate_ShouldNotFindPrivilegedItemInNestedBag()
        {
            Bag b1 = new Bag(new string[] { "bag1" }, "bag 1", "The first bag");
            Bag b2 = new Bag(new string[] { "bag2" }, "bag2", "The second bag");

            b1.Inventory.Put(b2);

            Item priviledgedItem = new Item(new string[] { "priviledged"},"priviledged item", "A priviledge item");
            b2.Inventory.Put(priviledgedItem);

            Assert.AreEqual(null, b1.Locate("privileged"));
        }
    }
}