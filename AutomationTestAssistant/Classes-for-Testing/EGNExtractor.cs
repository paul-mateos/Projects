using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public static class EGNExtractor
{
    private static string ReadEGNsFromFile(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        StringBuilder sb = new StringBuilder();
        using (reader)
        {
            string currentLine = reader.ReadLine();
            while (currentLine != null)
            {
                sb.Append(currentLine);
				
                currentLine = reader.ReadLine();
            }
        }
        string textFromFile = sb.ToString();

        return textFromFile;       
    }

    private static List<string> ExtractAllEGNs(string text)
    {
        string pattern = @"\b[0-9]{10}\b";
        MatchCollection matchesInText = Regex.Matches(text, pattern);  
        List<string> allEGNs = new List<string>();
        foreach (Match currentMatch in matchesInText)
        {
            allEGNs.Add(currentMatch.ToString());
        }

        return allEGNs;
    }

    public static void PrintAllEgnsFromFile(string fileName)
    {
        string text = ReadEGNsFromFile(fileName);
        List<string> allEGNs = ExtractAllEGNs(text);

        foreach (string currentEGN in allEGNs)
        {
            Console.WriteLine(currentEGN);
        }
    }
}

