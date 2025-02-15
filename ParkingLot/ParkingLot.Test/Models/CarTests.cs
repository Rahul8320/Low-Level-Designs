using ParkingLot.App.Exceptions;
using ParkingLot.App.Models;

namespace ParkingLot.Test.Models;

public class CarTests
{
    [Fact]
    public void Create_ValidRegistrationNumber_ReturnsCar()
    {
        // Arrange
        string registrationNumber = "KA-05-AA-1234";
        string color = "Red";

        // Act
        Car car = Car.Create(registrationNumber, color);

        // Assert
        Assert.Equal(registrationNumber, car.RegistrationNumber);
        Assert.Equal(color, car.Color);
    }

    [Theory]
    [InlineData("KA-05-AA-123")] // Too few digits
    [InlineData("KA-05-AAA-1234")] // Too many letters
    [InlineData("KA05AA1234")] // Missing hyphens
    [InlineData("ka-05-aa-1234")] // Lowercase letters (shouldn't be allowed)
    [InlineData("KA-05-AA-12345")] // Too many digits
    [InlineData("KA-05-AA-123A")] // Invalid char at end
    [InlineData("KA 05 AA 1234")] // Spaces instead of hyphens
    public void Create_InvalidRegistrationNumber_ThrowsInvalidRegistrationNumberException(string registrationNumber)
    {
        // Arrange
        string color = "Blue";

        // Act & Assert
        Assert.Throws<InvalidRegistrationNumberException>(() => Car.Create(registrationNumber, color));
    }


    [Theory]
    [InlineData("KA-05-AA-1234")]
    [InlineData("DL-02-CB-9876")]
    [InlineData("UP-16-AB-4321")]
    public void IsValidRegistrationNumber_ValidInput_ReturnsTrue(string registrationNumber)
    {
        Assert.True(Car.IsValidRegistrationNumber(registrationNumber));
    }

    [Theory]
    [InlineData("KA-05-AA-123")] // Too few digits
    [InlineData("KA-05-AAA-1234")] // Too many letters
    [InlineData("KA05AA1234")] // Missing hyphens
    [InlineData("ka-05-aa-1234")] // Lowercase letters (shouldn't be allowed)
    [InlineData("KA-05-AA-12345")] // Too many digits
    [InlineData("KA-05-AA-123A")] // Invalid char at end
    [InlineData("KA 05 AA 1234")] // Spaces instead of hyphens
    public void IsValidRegistrationNumber_InvalidInput_ReturnsFalse(string registrationNumber)
    {
        Assert.False(Car.IsValidRegistrationNumber(registrationNumber));
    }

    [Theory]
    [InlineData("KA-05-AA-123", "Registration number is invalid!")] // Too few digits
    [InlineData("KA-05-AAA-1234", "Registration number is invalid!")] // Too many letters
    [InlineData("KA05AA1234", "Registration number is invalid!")] // Missing hyphens
    [InlineData("ka-05-aa-1234", "Registration number is invalid!")] // Lowercase letters (shouldn't be allowed)
    [InlineData("KA-05-AA-12345", "Registration number is invalid!")] // Too many digits
    [InlineData("KA-05-AA-123A", "Registration number is invalid!")] // Invalid char at end
    [InlineData("KA 05 AA 1234", "Registration number is invalid!")] // Spaces instead of hyphens
    public void Create_InvalidRegistrationNumber_ThrowsInvalidRegistrationNumberException_CorrectMessage(string registrationNumber, string expectedMessage)
    {
        // Arrange
        string color = "Blue";

        // Act
        var exception = Assert.Throws<InvalidRegistrationNumberException>(() => Car.Create(registrationNumber, color));
        
        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }
}