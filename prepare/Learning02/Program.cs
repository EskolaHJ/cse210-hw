using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Carpet Insaller";
        job1._company = "NomadFloors";
        job1._startYear = 2015;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Dish Washer";
        job2._company = "Cafe Luciano";
        job2._startYear = 2017;
        job2._endYear = 2019;

        Resume myResume = new Resume();
        myResume._name = "Jacob Eskola";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}