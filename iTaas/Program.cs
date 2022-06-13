using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using CandidateTesting.LuizEugenioBarbieri.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.LuizEugenioBarbieri;

internal class Program
{
    static void Main(string[] args)
    {
        var programService = BuildProvider().GetRequiredService<IProgramService>();

        programService.ExecuteProgram(args[0], args[1]);
    }

    private static ServiceProvider BuildProvider()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        return serviceCollection.BuildServiceProvider();
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services
            .AddScoped<IProgramService, ProgramService>()
            .AddScoped<IStreamService, StreamService>()
            .AddScoped<IMinhaCdnService, MinhaCdnService>()
            .AddScoped<IConversorService, ConversorService>();
    }
}