using CandidateTesting.LuizEugenioBarbieri.FormatData.Formats;
using CandidateTesting.LuizEugenioBarbieri.Interfaces;

namespace CandidateTesting.LuizEugenioBarbieri.Services;

public class ProgramService : IProgramService
{
    private readonly IMinhaCdnService _minhaCdnService;
    private readonly IConversorService _conversorService;

    public ProgramService(IMinhaCdnService minhaCDNService, IConversorService conversorService)
    {
        _minhaCdnService = minhaCDNService;
        _conversorService = conversorService;
    }

    public void ExecuteProgram(string requestUri, string targetPath)
    {
        if (!requestUri.IsValidUri(out var uri))
        {
            Console.WriteLine("A URL informada não é uma URL válida.");
            return;
        }

        if (string.IsNullOrEmpty(targetPath))
        {
            Console.WriteLine("Informe o arquivo de destino.");
            return;
        }

        var logs = _minhaCdnService.GetLogs(uri);

        _conversorService.ConvertLogFile(new AgoraData(), logs, targetPath);

        Console.WriteLine($"O log foi convertido e salvo em {targetPath}!");
    }
}