using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string answer)
    {
        entries.Add(new Entry(DateTime.Now, prompt, answer));
    }

    public IEnumerable<Entry> GetEntries()
    {
        return entries;
    }

    public void SaveToFile()
    {
        string file = "journal.txt";
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry ent in entries)
            {
                outputFile.WriteLine(ent.GetDateTime().ToString("o")); 
                outputFile.WriteLine(ent.GetPrompt());
                outputFile.WriteLine(ent.GetEntry());
            }
        }
    }

    public void LoadFromFile()
    {
        string filename = "journal.txt";
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        entries.Clear();

        for (int i = 0; i < lines.Length; i += 3)
        {
            DateTime entryDate = DateTime.Parse(lines[i]);
            string entryPrompt = lines[i + 1];
            string entryContent = lines[i + 2];
            entries.Add(new Entry(entryDate, entryPrompt, entryContent));
        }
    }
}
