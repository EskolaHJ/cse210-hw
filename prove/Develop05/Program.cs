using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static bool _exitProgram = false;

    public static void Main(string[] args)
    {
        LoadGoals(); // Attempt to load goals at program start.
        MainMenu();
    }

    private static void MainMenu()
    {
        while (!_exitProgram)
        {
            ShowMenu();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    DisplayGoals();
                    break;
                case "3":
                    LoadGoals();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                case "exit":
                    _exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\nPlease choose an option:");
        Console.WriteLine("1. Create new Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Load Goals");
        Console.WriteLine("4. Record Events");
        Console.WriteLine("5. Save Goals");
        Console.WriteLine("6. Exit Program");
    }

    private static void AddGoal()
    {
        Console.WriteLine("Enter Goal Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Goal Type (Simple, Eternal, Checklist):");
        string type = Console.ReadLine();

        Console.WriteLine("Enter Value (Points):");
        int value = Convert.ToInt32(Console.ReadLine());

        switch (type?.ToLower())
        {
            case "simple":
                Console.WriteLine("Enter Bonus Points:");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());
                _goals.Add(new SimpleGoal(name, value, bonusPoints));
                break;
            case "eternal":
                _goals.Add(new EternalGoal(name, value));
                break;
            case "checklist":
                Console.WriteLine("Enter Desired Amount:");
                int desiredAmount = Convert.ToInt32(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, value, desiredAmount));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal added successfully!");
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Enter the Goal Name to record an event:");
        string name = Console.ReadLine();

        var goal = _goals.FirstOrDefault(g => g.GoalName.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (goal != null)
        {
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    private static void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            string status = goal.IsCompleted() ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {goal.GoalName} - Type: {goal.GoalType}");
        }
    }

    private static void SaveGoals()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(_goals, options);
        File.WriteAllText("goals.json", jsonString);
        Console.WriteLine("Goals saved successfully.");
    }

    private static void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string jsonString = File.ReadAllText("goals.json");
            _goals = JsonSerializer.Deserialize<List<Goal>>(jsonString);
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
