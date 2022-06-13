namespace CandidateTesting.LuizEugenioBarbieri.Interfaces;

public interface IStreamService
{
    Stream? TryGetStream(Uri requestUri);

    bool TryReadFile(Stream? file, out string stringFile);

    bool TrySaveFile(string file, string outPath);
}