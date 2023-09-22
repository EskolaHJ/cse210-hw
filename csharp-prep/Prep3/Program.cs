using System;

class Program
{
    static void Main(string[] args)
    {
        PlayGuessGame();
    }
    static void PlayGuessGame()
    {
        Random rand = new Random();
        int magicNumber = rand.Next(1,20);

        while (true)
        {
            Console.Write("What is your guess?");
            int guess;
            if (Int32.TryParse(Console.ReadLine(), out guess))
            {
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    break;
                }
            }
        }
    }
}
