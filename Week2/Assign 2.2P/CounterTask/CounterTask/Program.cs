namespace CounterTask
{
    internal class Program
    {
        private static void PrintCounters(Counter[] counters)
        {
           foreach (Counter c in counters)
           {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
           }
        }
        static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];
            myCounters[0] = new Counter ("Counter 1");
            myCounters[1] = new Counter ("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i = 1; i <= 9; i++)
            {
                myCounters[0].Increment();
            }
            for (int i = 1; i<=14; i++)
            {
                myCounters[1].Increment();
            }

            PrintCounters(myCounters);

            myCounters[2].Reset(); 

            PrintCounters(myCounters);

            //New instance of Counter class for testing large number
            //by default _count = 0
            Counter testCounter = new Counter("Test Counter");
            Console.WriteLine("{0} before ResetByDefault is {1}", testCounter.Name, testCounter.Ticks);

            testCounter.ResetByDefault();
            Console.WriteLine("{0} after ResetByDefault is {1}", testCounter.Name, testCounter.Ticks);

            testCounter.Increment();
            Console.WriteLine("{0} after Increment is {1}", testCounter.Name, testCounter.Ticks);


            //extending in week 3.2

            //Counter[]myCounters = null;
            //int X = 7;
            //myCounters[X].Increment(); 

        }
    }
}

//13.Tell the Counter to increase the count value. Does the code still run without any
//bugs/crash? What is the reason behind? You can provide the answers as the
//comments in the code.


// The code works fine with the "int" type for _count because we use "unchecked" 
// to handle overflow. The "int" type in C# can only hold values from -2,147,483,648 
// to 2,147,483,647. When setting _count to a value like 2,147,483,647,447, which 
// exceeds this range, it wraps around to a negative number. Incrementing this 
// wrapped value works within the int range, so the program continues running 
// without crashing.


