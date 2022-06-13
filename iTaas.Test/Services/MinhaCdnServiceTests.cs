using Bogus;
using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using CandidateTesting.LuizEugenioBarbieri.Services;
using Moq;
using System.Text;

namespace CandidateTesting.LuizEugenioBarbieri.Test.Services;

public class MinhaCdnServiceTests
{
    private readonly Faker _faker;
    private readonly Mock<IStreamService> _streamService;

    public MinhaCdnServiceTests()
    {
        _faker = new Faker();
        _streamService = new Mock<IStreamService>();
    }

    [Fact]
    public void Should_return_empty_list_when_cannot_read_file()
    {
        // Arrange
        var service = BuildService();

        var stringFile = It.IsAny<string>();

        _streamService
            .Setup(x => x.TryReadFile(It.IsAny<Stream?>(), out stringFile))
            .Returns(false);

        // Act
        var result = service.GetLogs(It.IsAny<Uri>());

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Should_return_not_empty_list_when_can_read_file()
    {
        // Arrange
        var service = BuildService();

        var builder = new StringBuilder();
        builder.AppendLine(_faker.Random.AlphaNumeric(12));
        var stringFile = builder.ToString();

        _streamService
            .Setup(x => x.TryReadFile(It.IsAny<Stream?>(), out stringFile))
            .Returns(true);

        // Act
        var result = service.GetLogs(It.IsAny<Uri>());

        // Assert
        Assert.NotEmpty(result);
    }

    private MinhaCdnService BuildService()
    {
        return new MinhaCdnService(_streamService.Object);
    }
}