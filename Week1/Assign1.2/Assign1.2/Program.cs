namespace Assign1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greetings from Message Object. My Student ID is 104809447");
            
            myMessage.Print();

            Message[] messages = new Message[5];
            messages[0] = new Message("Hi Jack, how are you?");
            messages[1] = new Message("Hi Will, how are you?");
            messages[2] = new Message("Hi Hector, how are you?");
            messages[3] = new Message("Welcome Admin");
            messages[4] = new Message("Welcome, nice to meet you");

            while (true)
            {
                Console.Write("Enter name:");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                {
                    break;
                }
                else if (name.ToLower() == "jack")
                {
                    messages[0].Print();
                }
                else if (name.ToLower() == "will")
                {
                    messages[1].Print();
                }
                else if (name.ToLower() == "hector")
                {
                    messages[2].Print();
                }
                else if (name.ToLower() == "kushagra")
                {
                    messages[3].Print();
                }
                else
                {
                    messages[4].Print();
                }
            }
        }
    }
}
