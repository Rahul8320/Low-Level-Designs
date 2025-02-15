namespace ParkingLot.App.Exceptions;

/// <summary>
/// Exception thrown when an invalid command is encountered.
/// </summary>
public class InvalidCommandException : Exception
{
    private new const string Message = "Invalid command exception!";

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidCommandException"/> class with a default message.
    /// </summary>
    public InvalidCommandException(): base(Message)
    {
        
    }
}
