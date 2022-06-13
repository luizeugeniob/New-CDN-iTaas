using CandidateTesting.LuizEugenioBarbieri.Models;

namespace CandidateTesting.LuizEugenioBarbieri.FormatData
{
    public interface IFormatData
    {
        string CreateData(List<MinhaCdn> minhaCDNs);
    }
}
