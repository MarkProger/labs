using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


var employees = new EmployeeCollection();

employees.Add(new SelfEmployedEmployee { Name = "Anna", MonthlyEarnings = 3000 });
employees.Add(new SalariedEmployee { Name = "Mark", Salary = 2500 });
employees.Add(new UnemployedEmployee { Name = "Mike" });
employees.Add(new SelfEmployedEmployee { Name = "Zara", MonthlyEarnings = 1500 });
employees.Add(new SalariedEmployee { Name = "Bob", Salary = 4000 });

Console.WriteLine("Sorted by Name:");
var byNameIterator = employees.GetSortedIterator(e => e.Name);
while (byNameIterator.MoveNext())
{
    Console.WriteLine(byNameIterator.Current);
}

Console.WriteLine("\nSorted by Income:");
var byIncomeIterator = employees.GetSortedIterator(e => e.Income);
while (byIncomeIterator.MoveNext())
{
    Console.WriteLine(byIncomeIterator.Current);
}

abstract class Employee
{
    public string Name { get; set; }
    public abstract double Income { get; }
    public abstract string EmploymentType { get; }

    public override string ToString() =>
        $"{Name} ({EmploymentType}) - Income: {Income}";
}

class SelfEmployedEmployee : Employee
{
    public double MonthlyEarnings { get; set; }

    public override double Income => MonthlyEarnings;
    public override string EmploymentType => "Self-Employed";
}

class SalariedEmployee : Employee
{
    public double Salary { get; set; }

    public override double Income => Salary;
    public override string EmploymentType => "Salaried";
}

class UnemployedEmployee : Employee
{
    public override double Income => 0.0;
    public override string EmploymentType => "Unemployed";
}

class EmployeeCollection : IEnumerable<Employee>
{
    private List<Employee> employees = new List<Employee>();

    public void Add(Employee employee) => employees.Add(employee);
    public int Count => employees.Count;
    public Employee this[int index] => employees[index];

    public IEnumerator<Employee> GetEnumerator() => employees.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public SortedEmployeeIterator GetSortedIterator(Func<Employee, object> sortBy) =>
        new SortedEmployeeIterator(this, sortBy);
}

class SortedEmployeeIterator : IEnumerator<Employee>
{
    private List<Employee> sortedList;
    private int position = -1;

    public SortedEmployeeIterator(EmployeeCollection collection, Func<Employee, object> sortBy)
    {
        sortedList = collection.OrderBy(sortBy).ToList();
    }

    public Employee Current => sortedList[position];
    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        position++;
        return (position < sortedList.Count);
    }

    public void Reset() => position = -1;
    public void Dispose() { }
}