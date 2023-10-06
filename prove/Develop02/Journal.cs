using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public string[] questions = {
        "Who affected your day the most today?",
        "What was the best part of your day?",
        "What blessings have you experienced today?",
        "Have you been able to help anyone today or make them smile?"
    };

    public void menuDisplay()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nPlease select a prompt");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("\nWhat would you like to do?");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Random rnd = new Random();
                    int num_question = rnd.Next(0, 4);
                    string selected_question = questions[num_question];
                    Console.WriteLine(selected_question);
                    string answer = Console.ReadLine();
                    entries.Add(new Entry(answer));
                    break;
                case 2:
                    foreach (Entry ent in entries)
                    {
                        Console.WriteLine("Date: " + ent.GetDateTime() + " Answer: " + ent.getEntry());
                    }
                    break;
                case 3:
                  Console.WriteLine("Loading from the file!");
                  LoadFromFile();

                    break;
                case 4:
                   Console.WriteLine("Saving to the file!");
                   SaveToFile();
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    break;
            }
        }
    }
    public void SaveToFile()
    {
        string file = "journal.txt";
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry ent in entries)
            {
                outputFile.WriteLine(ent.GetDateTime().ToString("o"));
                outputFile.WriteLine(ent.getEntry());
            }
        }
    }
    public void LoadFromFile()
    {
        string filename = "journal.txt";
        if (!File.Exists(filename)) return;
        
        string[] lines = File.ReadAllLines(filename);

        entries.Clear();
        for (int i = 0; i < lines.Length; i += 2)
        {
            DateTime entryDate = DateTime.Parse(lines[i]);
            string entryContent = lines[i + 1];

            entries.Add(new Entry(entryDate, entryContent));
        }
    }
}
