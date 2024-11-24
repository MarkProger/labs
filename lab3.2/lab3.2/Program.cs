using System;
using System.IO;


SalesCounter counter = SalesCounter.Instance;

counter.SellItem("food");
counter.SellItem("medicine");
counter.SellItem("clothing");
counter.SellItem("food");
counter.SellItem("clothing");
counter.SellItem("medicine");
counter.SellItem("food");

counter.PrintStatistics();

public sealed class SalesCounter
{
    private static readonly SalesCounter instance = new SalesCounter();
    private int foodCount;
    private int medicineCount;
    private int clothingCount;
    private double totalSalesValue;
    private readonly string logFilePath = "sales_log.txt";

    private SalesCounter()
    {
        File.WriteAllText(logFilePath, "Sales log:\n");
    }

    public static SalesCounter Instance
    {
        get { return instance; }
    }

    public void SellItem(string group)
    {
        double basePrice = new Random().Next(10, 100);
        double priceWithMarkup = basePrice;

        switch(group.ToLower())
        {
            case "food":
                foodCount++;
                priceWithMarkup *= 1.05;
                break;
            case "medicine":
                medicineCount++;
                priceWithMarkup *= 1.1;
                break;
            case "clothing":
                clothingCount++;
                priceWithMarkup *= 1.15;
                break;
            default:
                Console.WriteLine("Unknown item group");
                return;
        }

        totalSalesValue += priceWithMarkup;

        string logEntry = $"{DateTime.Now}: Sold item from {group} group, price: {priceWithMarkup:F2} UAH";
        File.AppendAllText(logFilePath, logEntry + "\n");

        Console.WriteLine(logEntry);
    }

    public void PrintStatistics()
    {
        Console.WriteLine("\nSales statistics:");
        Console.WriteLine($"Food items: {foodCount}");
        Console.WriteLine($"Medicine items: {medicineCount}");
        Console.WriteLine($"Clothing items: {clothingCount}");
        Console.WriteLine($"Total sales value: {totalSalesValue:F2} UAH");
    }
}