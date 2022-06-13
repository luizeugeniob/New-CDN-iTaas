using Bogus;
using CandidateTesting.LuizEugenioBarbieri.FormatData;
using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using CandidateTesting.LuizEugenioBarbieri.Models;
using CandidateTesting.LuizEugenioBarbieri.Services;
using Moq;

namespace CandidateTesting.LuizEugenioBarbieri.Test.Services;

public class ConversorServiceTests
{
    private readonly Faker _faker;
    private readonly Mock<IStreamService> _streamService;
    private readonly Mock<IFormatData> _formatData;

    public ConversorServiceTests()
    {
        _faker = new Faker();
        _streamService = new Mock<IStreamService>();
        _formatData = new Mock<IFormatData>();
    }

    [Fact]
    public void Should_not_save_file_when_new_data_is_null_or_empty()
    {
        // Arrange
        var service = BuildService();

        _formatData
            .Setup(x => x.CreateData(It.IsAny<List<MinhaCdn>>()))
            .Returns((string?)null);

        // Act
        service.ConvertLogFile(_formatData.Object, It.IsAny<List<MinhaCdn>>(), It.IsAny<string>());

        // Assert
        _streamService.Verify(x => x.TrySaveFile(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void Should_save_file_when_has_new_data()
    {
        // Arrange
        var service = BuildService();

        _formatData
            .Setup(x => x.CreateData(It.IsAny<List<MinhaCdn>>()))
            .Returns(_faker.Random.AlphaNumeric(12));

        // Act
        service.ConvertLogFile(_formatData.Object, It.IsAny<List<MinhaCdn>>(), It.IsAny<string>());

        // Assert
        _streamService.Verify(x => x.TrySaveFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    private ConversorService BuildService()
    {
        return new ConversorService(_streamService.Object);
    }
}