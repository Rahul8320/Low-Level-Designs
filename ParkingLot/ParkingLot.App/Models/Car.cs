using ParkingLot.App.Exceptions;
using System.Text.RegularExpressions;

namespace ParkingLot.App.Models;

public class Car
{
    public string RegistrationNumber { get; init; }

    public string Color { get; init; }

    private Car(string registrationNumber, string color)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
    }

    public static Car Create(string registrationNumber, string color)
    {
        if (IsValidRegistrationNumber(registrationNumber))
        {
            return new Car(registrationNumber, color);
        }

        throw new InvalidRegistrationNumberException();
    }

    public static bool IsValidRegistrationNumber(string registrationNumber)
    {
        // Regex pattern:  Two uppercase letters, a hyphen, two digits, a hyphen, two uppercase letters, a hyphen, four digits
        string pattern = @"^[A-Z]{2}-\d{2}-[A-Z]{2}-\d{4}$";

        Regex regex = new(pattern);

        return regex.IsMatch(registrationNumber);
    }
}
