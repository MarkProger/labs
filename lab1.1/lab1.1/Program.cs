using System;


Employer emp1 = new Employer("John", "MacAllister", CalculateDepartmentHeadSalary);
emp1.GetInfo();
Console.WriteLine("Salary: " + emp1.CalculateSalary());

Employer emp2 = new Employer("Jane", "Doe", CalculateSoftwareEngineerSalary);
emp2.GetInfo();
Console.WriteLine("Salary: " + emp2.CalculateSalary());

double CalculateDepartmentHeadSalary()
{
    return 10000;
}

double CalculateSoftwareEngineerSalary()
{
    return 6000;
}


delegate double SalaryCalculator();

class Employer
{
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private SalaryCalculator salaryCalculator;

    public Employer(string firstName, string lastName, SalaryCalculator salaryCalculator)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.salaryCalculator = salaryCalculator;
    }

    public void GetInfo()
    {
        Console.WriteLine("Name: " + this.FirstName + "\nSurname: " + this.LastName);
    }

    public double CalculateSalary()
    {
        return salaryCalculator();
    }
}