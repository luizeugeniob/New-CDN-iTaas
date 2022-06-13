using Bogus;
using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using CandidateTesting.LuizEugenioBarbieri.Services;
using Moq;

namespace CandidateTesting.LuizEugenioBarbieri.Test.Services;

public class ProgramServiceTests
{
    private readonly Faker _faker;
    private readonly Mock<IMinhaCdnService> _minhaCdnService;
    private readonly Mock<IConversorService> _conversorService;

    public ProgramServiceTests()
    {
        _faker = new Faker();
        _minhaCdnService = new Mock<IMinhaCdnService>();
        _conversorService = new Mock<IConversorService>();
    }

    [Fact]
    public void Should_not_get_logs_when_uri_is_invalid()
    {
        // Arrange
        var service = BuildService();

        // Act
        service.ExecuteProgram(It.IsAny<string>(), It.IsAny<string>());

        // Assert
        _minhaCdnService.Verify(x => x.GetLogs(It.IsAny<Uri>()), Times.Never);
    }

    [Fact]
    public void Should_not_get_logs_when_target_path_is_null_or_empty()
    {
        // Arrange
        var service = BuildService();

        // Act
        service.ExecuteProgram(_faker.Internet.Url(), string.Empty);

        // Assert
        _minhaCdnService.Verify(x => x.GetLogs(It.IsAny<Uri>()), Times.Never);
    }

    [Fact]
    public void Should_convert_file_when_parameters_are_valid()
    {
        // Arrange
        var service = BuildService();

        // Act
        service.ExecuteProgram(_faker.Internet.Url(), _faker.Random.String2(12));

        // Assert
        _minhaCdnService.Verify(x => x.GetLogs(It.IsAny<Uri>()), Times.Once);
    }

    private ProgramService BuildService()
    {
        return new ProgramService(_minhaCdnService.Object, _conversorService.Object);
    }
}