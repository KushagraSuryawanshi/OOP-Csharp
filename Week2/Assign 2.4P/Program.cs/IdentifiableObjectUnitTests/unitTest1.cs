using NUnit.Framework;
using Program;

namespace IdentifiableObjectUnitTests
{
    [TestFixture]
    public class IdentifiableObjectUnitTests
    {
        private IdentifiableObject id;

        [SetUp]
        public void Setup()
        {
            id = new IdentifiableObject(new string[] { "104809447", "Kushagra", "Suryawanshi" });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(id.AreYou("104809447"));
            Assert.IsTrue(id.AreYou("Kushagra"));
            Assert.IsTrue(id.AreYou("Suryawanshi"));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(id.AreYou("1O48O9447"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(id.AreYou("kUsHaGrA"));
            Assert.IsTrue(id.AreYou("sUrYaWaNsHi"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("104809447", id.FirstId);
        }

        [Test]
        public void TestFirstIdWithNoIDs()
        {
            var emptyId = new IdentifiableObject(new string[] { });
            Assert.AreEqual(string.Empty, emptyId.FirstId);
        }

        [Test]
        public void TestAddId()
        {
            id.AddIdentifier("NewIdentifier");
            Assert.IsTrue(id.AreYou("NewIdentifier"));
        }

        [Test]
        public void testPrivilegeEscalation()
        {
            id.PrivilegeEscalation("9447");

            Assert.AreEqual("Class 1-6-EN310-WED-10:30", id.FirstId);
        }
    }
}