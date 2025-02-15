namespace ParkingLot.App.Exceptions;

/// <summary>
/// Exception thrown when an invalid car registration number is encountered
/// </summary>
public class InvalidRegistrationNumberException: Exception
{
    /// <summary>
    /// Override the exception message
    /// </summary>
    private new const string Message = "Registration number is invalid!";

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidRegistrationNumberException"/> class
    /// </summary>
    public InvalidRegistrationNumberException(): base(Message)
    {
        
    }
}
