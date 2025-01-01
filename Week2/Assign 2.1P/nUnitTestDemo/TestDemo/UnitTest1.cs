using nUnitTestDemo;
namespace TestDemo
{
    public class Tests
    {
        private Employee employee;

        [SetUp]
        public void Setup()
        {
            employee = new Employee("John", "MERN STACK", 30, "Development");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("John", employee.getFirstName());
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual("MERN STACK", employee.getTechStack());
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(30, employee.getAge());
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual("Development", employee.getDepartment());
        }
    }
}