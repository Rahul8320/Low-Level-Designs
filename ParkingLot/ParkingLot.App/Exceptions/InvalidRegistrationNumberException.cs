namespace ParkingLot.App.Exceptions;

public class InvalidRegistrationNumberException: Exception
{
    private new const string Message = "Registration number is invalid!";
    
    public InvalidRegistrationNumberException(): base(Message)
    {
        
    }
}
