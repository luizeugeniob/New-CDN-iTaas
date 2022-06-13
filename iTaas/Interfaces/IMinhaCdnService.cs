using CandidateTesting.LuizEugenioBarbieri.Models;

namespace CandidateTesting.LuizEugenioBarbieri.Interfaces;

public interface IMinhaCdnService
{
    List<MinhaCdn> GetLogs(Uri requestUri);
}