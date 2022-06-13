using CandidateTesting.LuizEugenioBarbieri.FormatData;
using CandidateTesting.LuizEugenioBarbieri.Models;

namespace CandidateTesting.LuizEugenioBarbieri.Interfaces;

public interface IConversorService
{
    void ConvertLogFile(IFormatData formatData, List<MinhaCdn> minhaCDNs, string targetPath);
}
