using ParkingLot.App.Exceptions;
using System.Text.RegularExpressions;

namespace ParkingLot.App.Models;

/// <summary>
/// Represents a car with a registration number and color
/// </summary>
public class Car
{
    /// <summary>
    /// Gets the registration number of the car
    /// </summary>
    public string RegistrationNumber { get; init; }
    
    /// <summary>
    /// Gets the color of the car
    /// </summary>
    public string Color { get; init; }

    /// <summary>
    /// Private constructor to enforce creation through the Create method
    /// </summary>
    /// <param name="registrationNumber">The car's registration number</param>
    /// <param name="color">The car's color</param>
    private Car(string registrationNumber, string color)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
    }

    /// <summary>
    /// Creates a new Car instance if the provided registration number is valid
    /// </summary>
    /// <param name="registrationNumber">The car's registration number</param>
    /// <param name="color">The car's color/param>
    /// <returns>A new Car instance</returns>
    /// <exception cref="InvalidRegistrationNumberException">Thrown if the registration number is invalid</exception>
    public static Car Create(string registrationNumber, string color)
    {
        if (IsValidRegistrationNumber(registrationNumber))
        {
            return new Car(registrationNumber, color);
        }

        throw new InvalidRegistrationNumberException();
    }

    /// <summary>
    /// Checks if a registration number is valid according to the specified format
    /// </summary>
    /// <param name="registrationNumber">The registration number to validate</param>
    /// <returns>True if the registration number is valid, false otherwise</returns>
    public static bool IsValidRegistrationNumber(string registrationNumber)
    {
        // Regex pattern:  Two uppercase letters, a hyphen, two digits, a hyphen, two uppercase letters, a hyphen, four digits
        string pattern = @"^[A-Z]{2}-\d{2}-[A-Z]{2}-\d{4}$";

        Regex regex = new(pattern);

        return regex.IsMatch(registrationNumber);
    }
}
