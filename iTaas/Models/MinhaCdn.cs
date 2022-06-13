namespace CandidateTesting.LuizEugenioBarbieri.Models;

public class MinhaCdn
{
    public string CacheStatus { get; set; }
    public string HttpMethod { get; set; }
    public string ProtocolVersion { get; set; }
    public int ResponseSize { get; set; }
    public int StatusCode { get; set; }
    public decimal TimeTaken { get; set; }
    public string UriPath { get; set; }
}
