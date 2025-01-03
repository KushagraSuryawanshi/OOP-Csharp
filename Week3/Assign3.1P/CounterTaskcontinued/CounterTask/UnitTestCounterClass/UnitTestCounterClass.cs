using CounterTask;

namespace UnitTestCounterClass
{
    [TestFixture]
    public class Tests
    {
        private Counter _counter;

        [SetUp]
        public void Setup()
        {
            _counter = new Counter("TestCounter");
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(0, _counter.Ticks);
        }

        [Test]
        public void Test2()
        {
            _counter.Increment();
            Assert.AreEqual(1, _counter.Ticks);
        }

        [Test]
        public void Test3()
        {
            _counter.Increment();
            _counter.Increment();
            _counter.Increment();
            Assert.AreEqual(3, _counter.Ticks);
        }

        [Test]
        public void Test4()
        {
            _counter.Reset();
            Assert.AreEqual(0, _counter.Ticks);
        }
    }
}