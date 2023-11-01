using System;
using System.Threading;

abstract class BaseActivity
{
    protected string _name;
    protected string _description;
    protected int _durationInSeconds;

    public BaseActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Activity: {_name}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine("Please set the duration in seconds: ");
        _durationInSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public virtual void EndActivity()
    {
        Console.WriteLine("You've done a good job!");
        Console.WriteLine($"You have completed the {_name} activity for {_durationInSeconds} seconds.");
        ShowAnimation(3);
    }
}
