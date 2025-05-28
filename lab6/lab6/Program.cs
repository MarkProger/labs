using System;
using System.Collections.Generic;
using System.Threading;


IEmployeeDataSource dataSource = new EmployeeDataSourceProxy();

var employee1 = new Employee { Id = 1, Name = "John Doe", Position = "Developer" };
var employee2 = new Employee { Id = 2, Name = "Jane Smith", Position = "Designer" };

dataSource.WriteEmployee(employee1);
dataSource.WriteEmployee(employee2);

var readEmployee1 = dataSource.ReadEmployee(1);
Console.WriteLine(readEmployee1);

var readEmployee2 = dataSource.ReadEmployee(2);
Console.WriteLine(readEmployee2);

var readEmployee1Again = dataSource.ReadEmployee(1);
Console.WriteLine(readEmployee1Again);

public interface IEmployeeDataSource
{
    Employee ReadEmployee(int id);
    void WriteEmployee(Employee employee);
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Position: {Position}";
    }
}

public class EmployeeDataSource : IEmployeeDataSource
{
    private static Dictionary<int, Employee> _database = new Dictionary<int, Employee>();

    public Employee ReadEmployee(int id)
    {
        Console.WriteLine("Reading employee from database...");
        Thread.Sleep(2000);
        _database.TryGetValue(id, out var employee);
        return employee;
    }

    public void WriteEmployee(Employee employee)
    {
        Console.WriteLine("Writing employee to database...");
        Thread.Sleep(2000);
        _database[employee.Id] = employee;
    }
}

public static class DataSourceFactory
{
    public static IEmployeeDataSource CreateEmployeeDataSource()
    {
        return new EmployeeDataSource();
    }
}

public class EmployeeDataSourceProxy : IEmployeeDataSource
{
    private IEmployeeDataSource _realDataSource;
    private Dictionary<int, Employee> _cache = new Dictionary<int, Employee>();

    public EmployeeDataSourceProxy()
    {
        _realDataSource = DataSourceFactory.CreateEmployeeDataSource();
    }

    public Employee ReadEmployee(int id)
    {
        if (_cache.ContainsKey(id))
        {
            Console.WriteLine("Reading employee from cache...");
            return _cache[id];
        }

        var employee = _realDataSource.ReadEmployee(id);
        if (employee != null)
        {
            _cache[id] = employee;
        }
        return employee;
    }

    public void WriteEmployee(Employee employee)
    {
        _realDataSource.WriteEmployee(employee);
        _cache[employee.Id] = employee;
    }
}