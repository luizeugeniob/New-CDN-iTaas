namespace System;

public static class StringExtensions
{
    public static bool IsValidUri(this string uriString, out Uri? uri)
    {
        uri = null;

        try
        {
            uri = new Uri(uriString);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static List<string> GetDocumentLines(this string document) 
        => document.NormalizeFile().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

    public static string NormalizeFile(this string file) 
        => file.Replace("\"", "").Replace(" ", "|");

    public static string GetElementAt(this string text, int index)
    {
        return text
            .Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .ElementAtOrDefault(index) ?? string.Empty;
    }

    public static int SafeParseInt(this string s)
        => int.TryParse(s, out var number) ? number : 0;

    public static decimal SafeParseDecimal(this string s)
        => decimal.TryParse(s, out var number) ? number : 0;
}
