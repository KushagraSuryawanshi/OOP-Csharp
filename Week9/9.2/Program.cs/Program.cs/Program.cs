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

            // Create locations
            Location uni = new Location("Uni", "Swinburne University of Technology");
            Location library = new Location("Library", "A quiet place with many books");
            Location cafe = new Location("Cafe", "A small coffee shop on campus");

            // Set initial location
            _player.Location = uni;

            // Create paths
            Path pathToLibrary = new Path(new string[] { "north" }, library);
            Path pathToCafe = new Path(new string[] { "south" }, cafe, blocked: true);  // Blocked path to cafe

            // Add paths to locations
            uni.AddPath(pathToLibrary);
            uni.AddPath(pathToCafe);

            // Add items to the player's inventory
            Item bottle = new Item(new string[] { "bottle" }, "metal bottle", "A strong metal bottle");
            Item bat = new Item(new string[] { "bat" }, "baseball bag", "Burberry's baseball bag");

            _player.Inventory.Put(bottle);
            _player.Inventory.Put(bat);
            // Create and add nested items (bag, keyboard, etc.)
            Bag playerBag = new Bag(new string[] { "bag" }, "leather bag", "A bag containing everything");
            Item keyboard = new Item(new string[] { "keyboard" }, "mechanical keyboard", "A mechanical keyboard");
            playerBag.Inventory.Put(keyboard);

            Bag pouch = new Bag(new string[] { "pouch" }, "small pouch", "A small pouch with precious items");
            Item ring = new Item(new string[] { "ring" }, "golden ring", "A shiny golden ring");
            pouch.Inventory.Put(ring);
            playerBag.Inventory.Put(pouch);

            // Add playerBag to the player's inventory
            _player.Inventory.Put(playerBag);

            // Add an item to a location's inventory (e.g., Uni)
            Item gem = new Item(new string[] { "gem" }, "precious gem", "An expensive gemstone");
            uni.Inventory.Put(gem);

            // Commands (look and move)
            LookCommand lookCommand = new LookCommand();
            MoveCommand moveCommand = new MoveCommand();

            string command;
            do
            {
                Console.Write("\nEnter command (look/move/exit): ");
                command = Console.ReadLine().ToLower();

                if (command == "exit")
                {
                    break;
                }

                string[] commandParts = command.Split(' ');

                if (commandParts[0] == "look")
                {
                    string result = lookCommand.Execute(_player, commandParts);
                    Console.WriteLine(result);
                }
                else if (commandParts[0] == "move" || commandParts[0] == "go" || commandParts[0] == "head" || commandParts[0] == "leave")
                {
                    string result = moveCommand.Execute(_player, commandParts);
                    Console.WriteLine(result);
                }

            } while (command != "exit");
        }
    }
}