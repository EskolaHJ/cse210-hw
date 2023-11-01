using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : BaseActivity
{
    private static readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    public override void StartActivity()
    {
        base.StartActivity();

        Random random = new Random();
        string selectedPrompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine(selectedPrompt);
        Console.WriteLine("Get ready to start reflecting...");
        Thread.Sleep(3000); // Pause for 3 seconds before starting

        DateTime endTime = DateTime.Now.AddSeconds(_durationInSeconds);

        while (DateTime.Now < endTime)
        {
            string randomQuestion = _questions[random.Next(_questions.Count)];
            Console.WriteLine(randomQuestion);
            ShowSpinner(3);
        }

        EndActivity();
    }

    private void ShowSpinner(int seconds)
    {
        Console.CursorVisible = false;
        for (int i = 0; i < seconds * 10; i++)
        {
            switch (i % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Thread.Sleep(100);
        }
        Console.CursorVisible = true;
        Console.WriteLine(); // Clear the spinner
    }
}
