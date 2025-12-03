using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "ranking_raw.txt";
        string outputPath = "ranking_clean.txt";

        List<string> lines = new List<string>(File.ReadAllLines(inputPath));
        if (lines.Count == 0) return;

        List<string> cleaned = new List<string>();
        cleaned.Add(lines[0]);

        for (int i = 1; i < lines.Count; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] fields = line.Split(';');
            if (fields.Length != 5) continue;

            string nick = fields[0];
            string czas = fields[1];
            string punktyStr = fields[2];
            string status = fields[3];
            string opis = fields[4];

            if (!int.TryParse(punktyStr, out int punkty))
                punkty = 0;

            bool czyHaker =
                status.ToUpper() == "HACKER" ||
                czas == "00:00:01" ||
                czas == "0:00:01";

            if (czyHaker) continue;

            cleaned.Add($"{nick};{czas};{punkty};{status};{opis}");
        }

        File.WriteAllLines(outputPath, cleaned);

        foreach (string ln in File.ReadAllLines(outputPath))
            Console.WriteLine(ln);
    }
}