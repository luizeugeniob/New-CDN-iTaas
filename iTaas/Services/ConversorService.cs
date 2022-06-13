using CandidateTesting.LuizEugenioBarbieri.FormatData;
using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using CandidateTesting.LuizEugenioBarbieri.Models;

namespace CandidateTesting.LuizEugenioBarbieri.Services;

public class ConversorService : IConversorService
{
    private readonly IStreamService _streamService;

    public ConversorService(IStreamService streamService)
    {
        _streamService = streamService;
    }

    public void ConvertLogFile(IFormatData formatData, List<MinhaCdn> minhaCDNs, string targetPath)
    {
        var newData = formatData.CreateData(minhaCDNs);
        if (!string.IsNullOrEmpty(newData))
        {
            _streamService.TrySaveFile(newData, targetPath);
        }
    }
}