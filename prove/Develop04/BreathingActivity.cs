using System;
using System.Threading;

class BreathingActivity : BaseActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void StartActivity()
    {
        base.StartActivity();

        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds before starting

        DateTime endTime = DateTime.Now.AddSeconds(_durationInSeconds);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }

        EndActivity();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + "... ");
            Thread.Sleep(1000); // Pause for 1 second
            Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop); // Move cursor back
        }
        Console.WriteLine();
    }
}
