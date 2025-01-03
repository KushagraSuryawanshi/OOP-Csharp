using CounterTask;

namespace UnitTestClock
{
    [TestFixture]
    public class Tests
    {
        private Clock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }

        [Test]
        public void Test1()
        {
            string time = _clock.GetTime();

            Assert.AreEqual("00:00:00", time);
        }

        [Test]
        public void Test2()
        {
            _clock.Tick();
            string time = _clock.GetTime();

            Assert.AreEqual("00:00:01", time);
        }

        [Test]
        public void Test3()
        {
            for (int i = 0; i < 60; i++)
            {
                _clock.Tick();
            }
            Assert.AreEqual("00:01:00", _clock.GetTime());
        }

        [Test]
        public void Test4()
        {
            for (int i = 0; i < 3600; i++)
            {
                _clock.Tick();
            }
            Assert.AreEqual("01:00:00", _clock.GetTime());
        }

        [Test]
        public void Test5()
        {
            _clock.Reset();
            Assert.AreEqual("00:00:00", _clock.GetTime());
        }
    }
}