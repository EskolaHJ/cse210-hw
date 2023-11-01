using System;
using System.Threading;

class ListingActivity : BaseActivity
{
    private static readonly string[] _prompts = 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    public override void StartActivity()
    {
        base.StartActivity();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("Get ready to start listing...");
        Thread.Sleep(3000); // Pause for 3 seconds before starting

        DateTime endTime = DateTime.Now.AddSeconds(_durationInSeconds);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}
