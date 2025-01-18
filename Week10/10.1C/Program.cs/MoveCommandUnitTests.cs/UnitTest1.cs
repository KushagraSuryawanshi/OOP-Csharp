using NUnit.Framework;
using Program.cs;
using Path = Program.cs.Path;

[TestFixture]
public class MoveCommandTests
{
    private Player _player;
    private Location _startLocation;
    private Location _destinationLocation;
    private Path _northPath;
    private Path _eastPath;
    private MoveCommand _moveCommand;

    [SetUp]
    public void Setup()
    {
        // Create starting and destination locations
        _startLocation = new Location("Start", "Starting Room");
        _destinationLocation = new Location("Destination", "Destination Room");

        // Create paths
        _northPath = new Path(new string[] { "north" }, _destinationLocation);
        _eastPath = new Path(new string[] { "east" }, _destinationLocation, blocked: true);  // Blocked path

        _startLocation.AddPath(_northPath);  // Add valid path
        _startLocation.AddPath(_eastPath);   // Add blocked path

        // Create player and set their starting location
        _player = new Player("Player", "A brave adventurer");
        _player.Location = _startLocation;

        _moveCommand = new MoveCommand();
    }

    [Test]
    public void TestMoveToValidLocation()
    {
        // Execute the move command with a valid direction
        string response = _moveCommand.Execute(_player, new string[] { "move", "north" });

        // Assert that the player has moved to the destination location
        Assert.AreEqual("You head north and arrive at Destination", response);
        Assert.AreEqual(_destinationLocation, _player.Location); 
    }

    [Test]
    public void TestMoveToInvalidLocation()
    {
        // Execute the move command with an invalid direction
        string response = _moveCommand.Execute(_player, new string[] { "move", "south" });

        // Assert that the player remains in the starting location
        Assert.AreEqual("There is no path to the south", response);
        Assert.AreEqual(_startLocation, _player.Location); 
    }

    [Test]
    public void TestInvalidMoveCommandFormat()
    {
        // Invalid command with missing direction
        string response = _moveCommand.Execute(_player, new string[] { "move" });
        Assert.AreEqual("I don't know how to move like that", response);

        // Invalid command with extra words
        response = _moveCommand.Execute(_player, new string[] { "move", "north", "quickly" });
        Assert.AreEqual("I don't know how to move like that", response);
    }

    [Test]
    public void TestPathIdentification()
    {
        // Test that the path from "north" correctly leads to the destination
        Assert.AreEqual(_destinationLocation, _northPath.Destination); 
    }

    [Test]
    public void TestPathIsBlocked()
    {
        // Try to move through the blocked path
        string response = _moveCommand.Execute(_player, new string[] { "move", "east" });

        // Verify that the player cannot move
        Assert.AreEqual("The path is blocked.", response);
        Assert.AreEqual(_startLocation, _player.Location);  // Player should still be at the start location
    }
}
