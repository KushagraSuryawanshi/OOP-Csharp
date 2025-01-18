using NUnit.Framework;
using Program.cs;
using Path = Program.cs.Path;

namespace CommandProcessorUnitTests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor _commandProcessor;
        private Player _player;
        private Location _startLocation;
        private Location _destinationLocation;
        private Path _northPath;
        private Path _blockedPath;
        private MoveCommand _moveCommand;
        private LookCommand _lookCommand;

        [SetUp]
        public void Setup()
        {
            // Initialize the command processor and player
            _commandProcessor = new CommandProcessor();
            _player = new Player("Test Player", "A brave adventurer");

            // Create starting and destination locations
            _startLocation = new Location("Start", "Starting Room");
            _destinationLocation = new Location("Destination", "Destination Room");
            Location blockedLocation = new Location("Blocked", "A blocked path location");

            // Create paths: valid and blocked paths
            _northPath = new Path(new string[] { "north" }, _destinationLocation);
            _blockedPath = new Path(new string[] { "east" }, blockedLocation, blocked: true);

            _startLocation.AddPath(_northPath);  
            _startLocation.AddPath(_blockedPath);  

            _player.Location = _startLocation;

            // Initialize and add commands to the command processor
            _moveCommand = new MoveCommand();
            _lookCommand = new LookCommand();
            _commandProcessor.AddCommand(_moveCommand);
            _commandProcessor.AddCommand(_lookCommand);
        }

        [Test]
        public void TestMoveCommandExecution()
        {
            string[] commandInput = new string[] { "move", "north" };
            string result = _commandProcessor.ExecuteCommand(_player, commandInput);

            // Assert the expected output
            Assert.AreEqual("You head north and arrive at Destination", result); 
            Assert.AreEqual(_destinationLocation, _player.Location);  
        }

        [Test]
        public void TestBlockedPath()
        {
            string[] commandInput = new string[] { "move", "east" };
            string result = _commandProcessor.ExecuteCommand(_player, commandInput);

            Assert.AreEqual("The path is blocked.", result);
            Assert.AreEqual(_startLocation, _player.Location);
        }

        [Test]
        public void TestUnknownCommand()
        {
            // Simulate an unknown command
            string[] commandInput = new string[] { "fly", "north" };
            string result = _commandProcessor.ExecuteCommand(_player, commandInput);

            Assert.AreEqual("Unknown command: fly", result);
        }

        [Test]
        public void TestEmptyCommand()
        {
            string[] commandInput = new string[] { };
            string result = _commandProcessor.ExecuteCommand(_player, commandInput);

            Assert.AreEqual("No command entered!", result);
        }

        [Test]
        public void TestLookCommandExecution()
        {
            // Simulate the "look" command for the player's current location
            string[] commandInput = new string[] { "look" };
            string result = _commandProcessor.ExecuteCommand(_player, commandInput);

            Assert.AreEqual("Start: Starting Room", result); 
        }

        [Test]
        public void TestLookAtObjectInContainer()
        {
            Bag bag = new Bag(new string[] { "bag" }, "leather bag", "A leather bag");
            Item gem = new Item(new string[] { "gem" }, "shiny gem", "A sparkling gem");

            bag.Inventory.Put(gem); 
            _player.Inventory.Put(bag);  

            string[] commandInput = new string[] { "look", "at", "gem", "in", "bag" };
            string result = _commandProcessor.ExecuteCommand(_player, commandInput);

            Assert.AreEqual("A sparkling gem", result); 
        }
    }
}
