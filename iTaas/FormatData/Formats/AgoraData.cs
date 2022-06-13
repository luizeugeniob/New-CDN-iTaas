using CandidateTesting.LuizEugenioBarbieri.Models;
using System.Text;

namespace CandidateTesting.LuizEugenioBarbieri.FormatData.Formats;

public class AgoraData : IFormatData
{
    public string CreateData(List<MinhaCdn> minhaCDNs)
    {
        var builder = new StringBuilder();
        builder.AppendLine("#Version: 1.0");
        builder.AppendLine($"#Date: {DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")}");
        builder.AppendLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
        minhaCDNs.ForEach(log => builder.AppendLine($"\"MINHA CDN\"\t{log.HttpMethod}\t{log.StatusCode}\t{log.UriPath}\t{log.TimeTaken}\t{log.ResponseSize}\t{log.CacheStatus}"));
        return builder.ToString();
    }
}
