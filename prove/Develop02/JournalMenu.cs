using System;

public class JournalMenu
{
    private Journal _journal = new Journal();

    public string[] questions = {
        "Who affected your day the most today?",
        "What was the best part of your day?",
        "What blessings have you experienced today?",
        "Have you been able to help anyone today or make them smile?"
    };

    public void DisplayMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Random rnd = new Random();
                    int num_question = rnd.Next(0, 4);
                    string selected_question = questions[num_question];
                    Console.WriteLine(selected_question);
                    string answer = Console.ReadLine();
                    _journal.AddEntry(selected_question, answer);
                    break;
                case 2:
                    foreach (Entry ent in _journal.GetEntries())
                    {
                        Console.WriteLine("Date: " + ent.GetDateTime() + " Question: " + ent.GetPrompt() + " Answer: " + ent.GetEntry());
                    }
                    break;
                case 3:
                    Console.WriteLine("Loading from the file...");
                    _journal.LoadFromFile();
                    break;
                case 4:
                    Console.WriteLine("Saving to the file...");
                    _journal.SaveToFile();
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
