using System;

IJewelryFactory goldFactory = new GoldJewelryFactory();
IJewelryFactory silverFactory = new SilverJewelryFactory();

IEarrings goldEarrings = goldFactory.CreateEarrings(5m, 10m);
IRing silverRing = silverFactory.CreateRing(4m, 8m);


Console.WriteLine($"{goldEarrings.GetDescription()} - Price: {goldEarrings.CalculatePrice()}");
Console.WriteLine($"{silverRing.GetDescription()} - Price: {silverRing.CalculatePrice()}");

public interface IJewelry
{
    string GetDescription();
    decimal CalculatePrice();
}

public interface IEarrings : IJewelry { }

public interface IRing : IJewelry { }

public interface IChain : IJewelry { }

public interface IPendant : IJewelry { }

public interface IBracelet : IJewelry { }

public class GoldEarrings : IEarrings
{
    private decimal weight;
    private decimal complexity;

    public GoldEarrings(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Gold Earrings";
    }

    public decimal CalculatePrice()
    {
        decimal goldPricePerGram = 50m;
        return (weight * goldPricePerGram) + complexity;
    }
}

public class SilverEarrings : IEarrings
{
    private decimal weight;
    private decimal complexity;

    public SilverEarrings(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Silver Earrings";
    }

    public decimal CalculatePrice()
    {
        decimal silverPricePerGram = 25m;
        return (weight * silverPricePerGram) + complexity;
    }
}

public class GoldRing : IRing
{
    private decimal weight;
    private decimal complexity;

    public GoldRing(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Gold Ring";
    }

    public decimal CalculatePrice()
    {
        decimal goldPricePerGram = 50m;
        return (weight * goldPricePerGram) + complexity;
    }
}

public class SilverRing : IRing
{
    private decimal weight;
    private decimal complexity;

    public SilverRing(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Silver Ring";
    }

    public decimal CalculatePrice()
    {
        decimal silverPricePerGram = 25m;
        return (weight * silverPricePerGram) + complexity;
    }
}

public class GoldChain : IChain
{
    private decimal weight;
    private decimal complexity;

    public GoldChain(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Golden Chain";
    }

    public decimal CalculatePrice()
    {
        decimal goldPricePerGram = 50m;
        return (weight * goldPricePerGram) + complexity;
    }
}

public class SilverChain : IChain
{
    private decimal weight;
    private decimal complexity;

    public SilverChain(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Silver Chain";
    }

    public decimal CalculatePrice()
    {
        decimal silverPricePerGram = 25m;
        return (weight * silverPricePerGram) + complexity;
    }
}

public class GoldPendant : IPendant
{
    private decimal weight;
    private decimal complexity;

    public GoldPendant(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Gold Pendant";
    }

    public decimal CalculatePrice()
    {
        decimal goldPricePerGram = 50m;
        return (weight * goldPricePerGram) + complexity;
    }
}

public class SilverPendant : IPendant
{
    private decimal weight;
    private decimal complexity;

    public SilverPendant(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Silver Pendant";
    }

    public decimal CalculatePrice()
    {
        decimal silverPricePerGram = 25m;
        return (weight * silverPricePerGram) + complexity;
    }
}

public class GoldBracelet : IBracelet
{
    private decimal weight;
    private decimal complexity;

    public GoldBracelet(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Gold Bracelet";
    }

    public decimal CalculatePrice()
    {
        decimal goldPricePerGram = 50m;
        return (weight * goldPricePerGram) + complexity;
    }
}

public class SilverBracelet : IBracelet
{
    private decimal weight;
    private decimal complexity;

    public SilverBracelet(decimal weight, decimal complexity)
    {
        this.weight = weight;
        this.complexity = complexity;
    }

    public string GetDescription()
    {
        return "Silver Bracelet";
    }

    public decimal CalculatePrice()
    {
        decimal silverPricePerGram = 25m;
        return (weight * silverPricePerGram) + complexity;
    }
}

public interface IJewelryFactory
{
    IEarrings CreateEarrings(decimal weight, decimal complexity);
    IRing CreateRing(decimal weight, decimal complexity);
    IChain CreateChain(decimal weight, decimal complexity);
    IPendant CreatePendant(decimal weight, decimal complexity);
    IBracelet CreateBracelet(decimal weight, decimal complexity);
}

public class GoldJewelryFactory : IJewelryFactory
{
    public IEarrings CreateEarrings(decimal weight, decimal complexity)
    {
        return new GoldEarrings(weight, complexity);
    }

    public IRing CreateRing(decimal weight, decimal complexity)
    {
        return new GoldRing(weight, complexity);
    }

    public IChain CreateChain(decimal weight, decimal complexity)
    {
        return new GoldChain(weight, complexity);
    }

    public IPendant CreatePendant(decimal weight, decimal complexity)
    {
        return new GoldPendant(weight, complexity);
    }

    public IBracelet CreateBracelet(decimal weight, decimal complexity)
    {
        return new GoldBracelet(weight, complexity);
    }
}

public class SilverJewelryFactory : IJewelryFactory
{
    public IEarrings CreateEarrings(decimal weight, decimal complexity)
    {
        return new SilverEarrings(weight, complexity);
    }

    public IRing CreateRing(decimal weight, decimal complexity)
    {
        return new SilverRing(weight, complexity);
    }

    public IChain CreateChain(decimal weight, decimal complexity)
    {
        return new SilverChain(weight, complexity);
    }

    public IPendant CreatePendant(decimal weight, decimal complexity)
    {
        return new SilverPendant(weight, complexity);
    }

    public IBracelet CreateBracelet(decimal weight, decimal complexity)
    {
        return new SilverBracelet(weight, complexity);
    }
}

