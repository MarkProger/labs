using System;
using System.Collections.Generic;
using System.Linq;


var employees = new List<Employee>()
{
    new StaffEmployee { Name = "John", Qualification = new Junior(), OvertimeHours = 5},
    new ContractorEmployee { Name = "Steve", Qualification = new Middle(), OvertimeHours = 15},
    new StaffEmployee { Name = "Jack", Qualification = new Senior(), OvertimeHours = 20},
    new ContractorEmployee { Name = "Mike", Qualification = new Trainee(), OvertimeHours = 3},
    new StaffEmployee { Name = "Anne", Qualification = new CustomQualification("Expert", 1.5), OvertimeHours = 25},
};

for (int i = 1; i <= 6; i++)
{
    employees.Add(new ContractorEmployee { Name = $"№{i}", Qualification = new Junior(), OvertimeHours = 10 + i });
}

var payroll = new PayrollSystem(employees);
payroll.CalculateSalaries();
payroll.AwardTopOvertimeEmployees();

public abstract class Qualification
{
    public abstract string Level { get; }
    public abstract double SalaryMultiplier { get; }
}

public class Trainee : Qualification
{
    public override string Level => "Trainee"; 
    public override double SalaryMultiplier => 0.6; 
}
public class Junior : Qualification
{
    public override string Level => "Junior";
    public override double SalaryMultiplier => 0.8;
}

public class Middle : Qualification
{
    public override string Level => "Middle";
    public override double SalaryMultiplier => 1.0;
}

public class Senior : Qualification
{
    public override string Level => "Senior";
    public override double SalaryMultiplier => 1.3;
}

public class CustomQualification : Qualification
{
    private string _level;
    private double _multiplier;
    public CustomQualification(string level, double multiplier) { _level = level; _multiplier = multiplier; }
    public override string Level => _level;
    public override double SalaryMultiplier => _multiplier;
}

public abstract class Employee
{
    public virtual string Name { get; set; }
    public virtual Qualification Qualification { get; set; }
    public virtual int OvertimeHours { get; set; }
    public abstract double CalculateSalary();
}

public class StaffEmployee : Employee
{
    public override double CalculateSalary() => 40 * 20 * Qualification.SalaryMultiplier + OvertimeHours * 25;
}

public class ContractorEmployee : Employee
{
    public override double CalculateSalary() => 30 * 20 * Qualification.SalaryMultiplier + OvertimeHours * 20;
}

public abstract class EmployeeDecorator : Employee
{
    protected Employee _employee;
    protected EmployeeDecorator(Employee employee) { _employee = employee; }

    public override double CalculateSalary() => _employee.CalculateSalary();

    public override string Name { get => _employee.Name; set => _employee.Name = value; }

    public override Qualification Qualification { get => _employee.Qualification; set => _employee.Qualification = value; }

    public override int OvertimeHours { get => _employee.OvertimeHours; set => _employee.OvertimeHours = value; }
}


public class BonusDecorator : EmployeeDecorator
{
    public BonusDecorator(Employee employee) : base(employee) { }
    public override double CalculateSalary() => base.CalculateSalary() + 500;
}

public class PayrollSystem
{
    private List<Employee> _employees;
    public PayrollSystem(List<Employee> employees)
    {
        _employees = employees;
    }

    public void ChangeQualification(Employee employee, Qualification qualification)
    {
        employee.Qualification = qualification;
    }

    public void CalculateSalaries()
    {
        foreach (Employee emp in _employees)
        {
            Console.WriteLine($"{emp.Name} ({emp.Qualification.Level}) - Salary: {emp.CalculateSalary():F2}");
        }
    }

    public void AwardTopOvertimeEmployees()
    {
        var top10 = _employees.OrderByDescending(e => e.OvertimeHours).Take(10).ToList();
        Console.WriteLine("\nTop 10 Employees with most overtime:");
        foreach (var emp in top10)
        {
            var bonusEmp = new BonusDecorator(emp);
            Console.WriteLine($"{bonusEmp.Name} - Overtime: {bonusEmp.OvertimeHours} - Salary with Bonus: {bonusEmp.CalculateSalary():F2}");
        }
    }
}

