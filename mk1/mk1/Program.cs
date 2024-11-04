using System;

IVehicleFactory fordFactory = new FordFactory();
Vehicle fordSedan = fordFactory.CreateSedan();
Vehicle fordSUV = fordFactory.CreateSUV();
Vehicle fordTruck = fordFactory.CreateTruck();

fordSedan.Drive();
fordSUV.Drive();
fordTruck.Drive();

IVehicleFactory mitsubishiFactory = new MitsubishiFactory();
Vehicle mitsubishiSedan = mitsubishiFactory.CreateSedan();
Vehicle mitsubishiSUV = mitsubishiFactory.CreateSUV();
Vehicle mitsubishiTruck = mitsubishiFactory.CreateTruck();

mitsubishiSedan.Drive();
mitsubishiSUV.Drive();
mitsubishiTruck.Drive();

abstract class Vehicle
{
    public abstract void Drive();
}

class Sedan : Vehicle
{
    private string _brand;
    public Sedan(string brand)
    {
        _brand = brand;
    }
    public override void Drive()
    {
        Console.WriteLine($"{_brand} Sedan is driving.");
    }
}

class SUV : Vehicle
{
    private string _brand;
    public SUV(string brand)
    {
        _brand = brand;
    }

    public override void Drive()
    {
        Console.WriteLine($"{_brand} SUV is driving.");
    }
}

class Truck : Vehicle
{
    private string _brand;
    public Truck(string brand)
    {
        _brand = brand;
    }

    public override void Drive()
    {
        Console.WriteLine($"{_brand} Truck is driving.");
    }
}

interface IVehicleFactory
{
    Vehicle CreateSedan();
    Vehicle CreateSUV();
    Vehicle CreateTruck();
}

class FordFactory : IVehicleFactory
{
    public Vehicle CreateSedan()
    {
        return new Sedan("Ford");
    }

    public Vehicle CreateSUV()
    {
        return new SUV("Ford");
    }

    public Vehicle CreateTruck()
    {
        return new Truck("Ford");
    }
}

class MitsubishiFactory : IVehicleFactory
{
    public Vehicle CreateSedan()
    {
        return new Sedan("Mitsubishi");
    }

    public Vehicle CreateSUV()
    {
        return new SUV("Mitsubishi");
    }

    public Vehicle CreateTruck()
    {
        return new Truck("Mitsubishi");
    }
}