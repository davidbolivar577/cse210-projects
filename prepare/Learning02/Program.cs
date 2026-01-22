using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        job1._company = "Company A";
        job1._jobTitle = "Basic Job";
        job1._startYear = 2021;
        job1._endYear = 2024;

        Job job2 = new();
        job2._company = "Company B";
        job2._jobTitle = "Slightly Better Job";
        job2._startYear = 2024;
        job2._endYear = 2026;

        Resume resume = new();
        resume._name = "David Bolivar";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}