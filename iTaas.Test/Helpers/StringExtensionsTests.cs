using Bogus;

namespace CandidateTesting.LuizEugenioBarbieri.Test.Helpers;

public class StringExtensionsTests
{
    private readonly Faker _faker;

    public StringExtensionsTests()
    {
        _faker = new Faker();
    }

    [Fact]
    public void Should_return_false_when_uri_is_invalid()
    {
        // Arrange & Act
        var result = _faker.Random.AlphaNumeric(12).IsValidUri(out var uri);

        // Assert
        Assert.False(result);
        Assert.Null(uri);
    }

    [Fact]
    public void Should_return_true_when_uri_is_valid()
    {
        // Arrange & Act
        var result = _faker.Internet.Url().IsValidUri(out var uri);

        // Assert
        Assert.True(result);
        Assert.NotNull(uri);
    }

    [Fact]
    public void Should_return_string_empty_when_file_has_only_quotation_marks()
    {
        // Arrange & Act
        var result = "\"".NormalizeFile();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Should_return_pipeline_when_file_has_only_space()
    {
        // Arrange & Act
        var result = " ".NormalizeFile();

        // Assert
        Assert.Equal("|", result);
    }
    
    [Fact]
    public void Should_return_string_empty_when_hasnt_element_at_specified_index()
    {
        // Arrange & Act
        var result = "a|b|".GetElementAt(10);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Should_return_element_when_has_element_at_specified_index()
    {
        // Arrange & Act
        var result = "a|b|".GetElementAt(1);

        // Assert
        Assert.Equal("b", result);
    }

    [Fact]
    public void Should_return_zero_when_string_is_not_integer()
    {
        // Arrange & Act
        var result = _faker.Random.String2(12).SafeParseInt();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Should_return_integer_when_string_is_integer()
    {
        // Arrange
        var number = _faker.Random.Number(12);

        // Act
        var result = number.ToString().SafeParseInt();

        // Assert
        Assert.Equal(number, result);
    }

    [Fact]
    public void Should_return_zero_when_string_is_not_decimal()
    {
        // Arrange & Act
        var result = _faker.Random.String2(12).SafeParseDecimal();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Should_return_decimal_when_string_is_decimal()
    {
        // Arrange
        var number = _faker.Random.Decimal(1, 999);

        // Act
        var result = number.ToString().SafeParseDecimal();

        // Assert
        Assert.Equal(number, result);
    }
}