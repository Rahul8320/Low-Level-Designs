using ParkingLot.App.Exceptions;
using ParkingLot.App.Models;

namespace ParkingLot.Test.Models;

public class CommandTests
{
    [Fact]
    public void Create_ValidInput_ReturnsCommand()
    {
        // Arrange
        string inputLine = "MyCommand Param1 Param2";

        // Act
        Command command = Command.Create(inputLine);

        // Assert
        Assert.Equal("mycommand", command.CommandName);
        Assert.Equal(2, command.Params.Count);
        Assert.Equal("Param1", command.Params[0]);
        Assert.Equal("Param2", command.Params[1]);
    }

    [Fact]
    public void Create_InputWithExtraSpaces_TrimsSpaces()
    {
        // Arrange
        string inputLine = "  MyCommand   Param1  Param2   ";

        // Act
        Command command = Command.Create(inputLine);

        // Assert
        Assert.Equal("mycommand", command.CommandName);
        Assert.Equal(2, command.Params.Count);
        Assert.Equal("Param1", command.Params[0]);
        Assert.Equal("Param2", command.Params[1]);
    }

    [Fact]
    public void Create_InputWithMixedCase_ReturnsLowercaseCommandName()
    {
        // Arrange
        string inputLine = "MyCommand Param1 Param2";

        // Act
        Command command = Command.Create(inputLine);

        // Assert
        Assert.Equal("mycommand", command.CommandName);
    }


    [Fact]
    public void Create_NoParams_ReturnsCommandWithEmptyParams()
    {
        // Arrange
        string inputLine = "MyCommand";

        // Act
        Command command = Command.Create(inputLine);

        // Assert
        Assert.Equal("mycommand", command.CommandName);
        Assert.Empty(command.Params);
    }

    [Theory]
    [InlineData("")] // Empty string
    [InlineData("   ")] // Whitespace string
    public void Create_EmptyOrWhitespaceInput_ThrowsInvalidCommandException_CorrectMessage(string inputLine)
    {
        // Act & Assert
        var exception = Assert.Throws<InvalidCommandException>(() => Command.Create(inputLine));
        Assert.Equal("Invalid command exception!", exception.Message);
    }


    [Fact]
    public void Create_NoCommandName_ThrowsInvalidCommandException_CorrectMessage()
    {
        // Arrange
        string inputLine = " ";

        // Act & Assert
        var exception = Assert.Throws<InvalidCommandException>(() => Command.Create(inputLine));
        Assert.Equal("Invalid command exception!", exception.Message);
    }

    [Fact]
    public void Create_MultipleSpacesBetweenParams_HandlesCorrectly()
    {
        // Arrange
        string inputLine = "MyCommand   Param1     Param2";

        // Act
        Command command = Command.Create(inputLine);

        // Assert
        Assert.Equal("mycommand", command.CommandName);
        Assert.Equal(2, command.Params.Count);
        Assert.Equal("Param1", command.Params[0]);
        Assert.Equal("Param2", command.Params[1]);
    }
}