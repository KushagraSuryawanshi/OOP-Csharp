using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitTestDemo
{
    public class Employee
    {
        private string firstName;
        private string techStack;
        private int age;
        private string department;

        public Employee(string _firstName, string _techStack, int _age, string _department)
        { 
            firstName = _firstName;
            techStack = _techStack;
            age = _age;
            department = _department;
        }

        public string getFirstName()
        {
            return firstName;
        }
        public string getTechStack()
        {
            return techStack;
        }
        public int getAge()
        {
            return age;
        }
        public string getDepartment()
        {
            return department;
        }
    }
}
