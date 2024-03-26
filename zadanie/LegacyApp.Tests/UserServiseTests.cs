namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenLastNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            null, 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail
    [Fact] 
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalskikowalskipl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.False(result);
    }
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld
    [Fact] 
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2020-04-30"),
            1
        );

        // Assert
        Assert.False(result);
    }

    // AddUser_ReturnsTrueWhenVeryImportantClient
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );

        // Assert
        Assert.True(result);
    }
    // AddUser_ReturnsTrueWhenImportantClient
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            3
        );

        // Assert
        Assert.True(result);
    }
    // AddUser_ReturnsTrueWhenNormalClient
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        var userService = new UserService();
        // Act
        
        
        var result = userService.AddUser(
            "Jan", 
            "Kwiatkowski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );
    
        // Assert
        Assert.True(result);
    }
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        var userService = new UserService();
        // Act
        
        
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );
    
        // Assert
        Assert.False(result);
    }
    // AddUser_ThrowsExceptionWhenUserDoesNotExist
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Cokolwiek", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    
    }
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jacek", 
            "Sasin", 
            "wydal@70milionow.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    
}