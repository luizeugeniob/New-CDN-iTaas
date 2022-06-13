using CandidateTesting.LuizEugenioBarbieri.Interfaces;
using System.Text;

namespace CandidateTesting.LuizEugenioBarbieri.Services;

public class StreamService : IStreamService
{
    public Stream? TryGetStream(Uri requestUri)
    {
        try
        {
            using var client = new HttpClient();
            return client.GetStreamAsync(requestUri).Result;
        }
        catch (Exception)
        {
            Console.Write("Este arquivo não pode ser lido.");
            return null;
        }
    }

    public bool TryReadFile(Stream? file, out string stringFile)
    {
        stringFile = string.Empty;

        if (file is null) return false;

        try
        {
            using var stream = new MemoryStream();

            byte[] buffer = new byte[2048];
            int bytesRead;
            while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
            {
                stream.Write(buffer, 0, bytesRead);
            }
            byte[] result = stream.ToArray();
            stringFile = Encoding.UTF8.GetString(result, 0, result.Length - 1);
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("O arquivo não pode ser lido.");
            return false;
        }
    }

    public bool TrySaveFile(string file, string outPath)
    {
        try
        {
            var folderPath = Path.GetDirectoryName(outPath);

            if (string.IsNullOrEmpty(folderPath)) return false;

            Directory.CreateDirectory(folderPath);
            var filename = Path.GetFileName(outPath);
            var fullPath = Path.Combine(folderPath, filename);
            byte[] fileBytes = new UTF8Encoding(true).GetBytes(file);

            using var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 2048);
            fs.Write(fileBytes, 0, fileBytes.Length);
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("O arquivo não pode ser salvo.");
            return false;
        }
    }
}