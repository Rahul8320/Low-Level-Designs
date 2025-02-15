using ParkingLot.App.Exceptions;

namespace ParkingLot.App.Models;

/// <summary>
/// Represents a command with a name and a list of parameters
/// </summary>
public class Command
{
    private const string SPACE = " ";

    /// <summary>
    /// Gets the name of the command
    /// </summary>
    public string CommandName { get; init; }

    /// <summary>
    /// Gets the list of parameters for the command
    /// </summary>
    public List<string> Params { get; init; }

    /// <summary>
    /// Private constructor to enforce creation through the Create method
    /// </summary>
    /// <param name="commandName">The name of the command</param>
    /// <param name="params">The list of parameters</param>
    private Command(string commandName, List<string> _params)
    {
        CommandName = commandName;
        Params = _params;
    }

    /// <summary>
    /// Creates a new Command instance from a string input line
    /// </summary>
    /// <param name="inputLine">The input line containing the command and parameters</param>
    /// <returns>A new Command instance</returns>
    /// <exception cref="InvalidCommandException">Thrown if the input line is invalid or contains no command name</exception>
    public static Command Create(string inputLine)
    {
        if (string.IsNullOrWhiteSpace(inputLine))
        {
            throw new InvalidCommandException();
        }

        List<string> tokensList = [.. inputLine.Split(SPACE)
            .Select(token => token.Trim())
            .Where(token => string.IsNullOrWhiteSpace(token) == false)];

        if (tokensList.Count == 0)
        {
            throw new InvalidCommandException();
        }

        var commandName = tokensList[0].ToLower();
        tokensList.RemoveAt(0);

        return new Command(commandName, tokensList);
    }
}
