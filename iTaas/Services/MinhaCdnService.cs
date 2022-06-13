using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using CandidateTesting.LuizEugenioBarbieri.Models;

namespace CandidateTesting.LuizEugenioBarbieri.Services;

public class MinhaCdnService : IMinhaCdnService
{
    private readonly IStreamService streamService;

    public MinhaCdnService(IStreamService streamService)
    {
        this.streamService = streamService;
    }

    public List<MinhaCdn> GetLogs(Uri requestUri)
    {
        var file = streamService.TryGetStream(requestUri);
        if (streamService.TryReadFile(file, out string document))
        {
            var lines = document.GetDocumentLines();

            return (from line in lines
                    select new MinhaCdn
                    {
                        CacheStatus = line.GetElementAt(2),
                        HttpMethod = line.GetElementAt(3),
                        ProtocolVersion = line.GetElementAt(5),
                        ResponseSize = line.GetElementAt(0).SafeParseInt(),
                        StatusCode = line.GetElementAt(1).SafeParseInt(),
                        TimeTaken = line.GetElementAt(6).SafeParseDecimal(),
                        UriPath = line.GetElementAt(4)
                    })
                    .ToList();
        }

        return new List<MinhaCdn>();
    }
}