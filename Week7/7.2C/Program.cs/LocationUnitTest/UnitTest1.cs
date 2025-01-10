using System.Numerics;
using Program.cs;
namespace LocationUnitTest
{
    [TestFixture]
    public class Tests
    {
        private Player _player;
        private Location _location;
        private Item _item;
        private Bag _outerBag;
        private Bag _innerBag;
        private Item _nestedItem;
        [SetUp]
        public void Setup()
        {
            _player = new Player("Kushagra", "104809447");
            _location = new Location("Uni", "Swinburne University of Technology");
            _item = new Item(new string[] { "gem" }, "Gemstone", "An expensive gemstone");

            _player.Location = _location;
            _location.Inventory.Put(_item);

            _outerBag = new Bag(new string[] { "outerbag" }, "leather bag", "A large leather bag");
            _innerBag = new Bag(new string[] { "innerbag" }, "small pouch", "A small pouch inside the leather bag");
            _nestedItem = new Item(new string[] { "ring" }, "Golden Ring", "A precious golden ring");

            _outerBag.Inventory.Put(_innerBag);  
            _innerBag.Inventory.Put(_nestedItem); 
            _player.Inventory.Put(_outerBag);
        }

        [Test]
        public void TestLocationCanIdentifyItself()
        {
            Assert.IsTrue(_location.AreYou("uni"));
            Assert.AreEqual("Uni", _location.Name);
            Assert.AreEqual("Uni: Swinburne University of Technology", _location.FullDescription);
        }

        [Test]
        public void TestLocationCanLocateItem()
        {
            GameObject locatedItem = _location.Locate("gem");
            Assert.IsNotNull(locatedItem);
            Assert.AreEqual(_item, locatedItem);
        }

        [Test]
        public void TestPlayerCanLocateItemInLocation()
        {
            GameObject locatedItem = _player.Locate("gem");
            Assert.IsNotNull(locatedItem);
            Assert.AreEqual(_item, locatedItem);
        }

        [Test]
        public void TestPlayerCanLocateItemInNestedBag()
        {
            GameObject locatedOuterBag = _player.Locate("outerbag");
            Assert.IsNotNull(locatedOuterBag);
            Assert.AreEqual(_outerBag, locatedOuterBag);

            // Locate the inner bag directly from the outer bag
            GameObject locatedInnerBag = _outerBag.Inventory.Fetch("innerbag");
            Assert.IsNotNull(locatedInnerBag);
            Assert.AreEqual(_innerBag, locatedInnerBag);

            // Locate the nested item (ring) directly from the inner bag
            GameObject locatedRing = _innerBag.Inventory.Fetch("ring");
            Assert.IsNotNull(locatedRing);
            Assert.AreEqual(_nestedItem, locatedRing);
        }
    }
}