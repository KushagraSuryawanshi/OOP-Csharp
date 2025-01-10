namespace Program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kushagra, 104809447");

            Console.Write("Enter player's name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter player's description: ");
            string playerDescription = Console.ReadLine();

            Player _player = new Player(playerName, playerDescription);

            Item bottle = new Item(new string[] {"bottle"}, "metal bottle", "A strong metal bottle");
            Item bat = new Item(new string[] { "bat" }, "baseball bag", "burberry's baseball bag");

            _player.Inventory.Put(bottle);
            _player.Inventory.Put(bat);

            Bag _bag = new Bag(new string[] { "bag" }, "leather bag", "Player's bag containing everything");
            _player.Inventory.Put(_bag);

            Item keyboard = new Item(new string[] { "keyboard" }, "mechanical keyboard", "This keyboard is hard to fit in bag");

            _bag.Inventory.Put(keyboard);

            LookCommand lookCommand = new LookCommand();

            string command;
            do
            {
                Console.Write("\nEnter command (look/exit): ");
                command = Console.ReadLine().ToLower();

                if (command == "exit")
                {
                    break;
                }

                string[] commandParts = command.Split(' ');
                string result = lookCommand.Execute(_player, commandParts);

                Console.WriteLine(result);

            } while (command != "exit");

        }
    }
}
