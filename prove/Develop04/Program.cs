using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Activity Program!");
        Console.WriteLine("Please choose an activity:");
        Console.WriteLine("1 - Breathing");
        Console.WriteLine("2 - Reflection");
        Console.WriteLine("3 - Listing");
        Console.Write("Enter the number of the activity you wish to start: ");
        
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                var breathingActivity = new BreathingActivity();
                breathingActivity.StartActivity();
                break;
            case "2":
                var reflectionActivity = new ReflectionActivity();
                reflectionActivity.StartActivity();
                break;
            case "3":
                var listingActivity = new ListingActivity();
                listingActivity.StartActivity();
                break;
            default:
                Console.WriteLine("Invalid selection. Please run the program again.");
                break;
        }
    }
}
