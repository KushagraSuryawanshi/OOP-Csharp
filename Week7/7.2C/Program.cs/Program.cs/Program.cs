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

            // Create a location (e.g., University)
            Location uni = new Location("Uni", "Swinburne University of Technology");
            _player.Location = uni;  // Assign the player's location

            // Add items to the player's inventory
            Item bottle = new Item(new string[] { "bottle" }, "metal bottle", "A strong metal bottle");
            Item bat = new Item(new string[] { "bat" }, "baseball bag", "Burberry's baseball bag");

            _player.Inventory.Put(bottle);
            _player.Inventory.Put(bat);

            // Create a bag and nest items inside it
            Bag _bag = new Bag(new string[] { "bag" }, "leather bag", "Player's bag containing everything");
            _player.Inventory.Put(_bag);

            Item keyboard = new Item(new string[] { "keyboard" }, "mechanical keyboard", "This keyboard is hard to fit in the bag");
            _bag.Inventory.Put(keyboard);

            // Create a nested bag (inside the leather bag)
            Bag _innerBag = new Bag(new string[] { "pouch" }, "small pouch", "A small pouch with precious items");
            _bag.Inventory.Put(_innerBag);

            // Put items in the nested bag
            Item ring = new Item(new string[] { "ring" }, "golden ring", "A shiny golden ring");
            _innerBag.Inventory.Put(ring);

            // Add an item to the location's inventory
            Item gem = new Item(new string[] { "gem" }, "precious gem", "An expensive gemstone");
            uni.Inventory.Put(gem);

            // Initialize the LookCommand to handle 'look' operations
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
