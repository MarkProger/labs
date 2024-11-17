using System;


Director director = new Director();

double lollipopPrice = GetValidDouble("Введiть цiну за кг льодяникiв:");
double chocolatePrice = GetValidDouble("Введiть цiну за кг шоколадних цукерок:");
double wafflesPrice = GetValidDouble("Введiть цiну за кг вафель:");
double drageePrice = GetValidDouble("Введiть цiну за кг драже:");

Console.WriteLine("\nВиберiть тип подарункового набору: 1 - Ласунка, 2 - Наминайко, 3 - Пан Коцький");
int choice = GetValidInt("Введiть ваш вибір (1, 2 або 3):");

IGiftSetBuilder builder;
switch (choice)
{
    case 1:
        builder = new EconomyGiftSetBuilder();
        break;
    case 2:
        builder = new StandardGiftSetBuilder();
        break;
    case 3:
        builder = new PremiumGiftSetBuilder();
        break;
    default:
        Console.WriteLine("Неправильний вибiр");
        return;
}

director.SetBuilder(builder);
GiftSet giftSet = director.ConstructGiftSet(lollipopPrice, chocolatePrice, wafflesPrice, drageePrice);
giftSet.ShowDetails();

static double GetValidDouble(string prompt)
{
    double value;
    while (true)
    {
        Console.WriteLine(prompt);
        if (double.TryParse(Console.ReadLine(), out value))
        {
            return value;
        }
        Console.WriteLine("Неправильний ввiд. Будь ласка, введiть число.");
    }
}

static int GetValidInt(string prompt)
{
    int value;
    while (true)
    {
        Console.WriteLine(prompt);
        if (int.TryParse(Console.ReadLine(), out value))
        {
            return value;
        }
        Console.WriteLine("Неправильний ввiд. Будь ласка, введiть цiле число.");
    }
}
class GiftSet
{
    public string Name { get; set; }
    public double LollipopsWeight { get; set; }
    public double ChocolateWeight { get; set; }
    public double WafflesWeight { get; set; }
    public double DrageeWeight { get; set; }
    public double Price {  get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"Назва набору: {Name}");
        Console.WriteLine($"Вага льодяникiв: {LollipopsWeight} кг");
        Console.WriteLine($"Вага шоколадних цукерок: {ChocolateWeight} кг");
        Console.WriteLine($"Вага вафель: {WafflesWeight} кг");
        Console.WriteLine($"Вага драже: {DrageeWeight} кг");
        Console.WriteLine($"Цiна набору: {Price} грн");
    }
}
// Builder interface
interface IGiftSetBuilder
{
    void SetName();
    void SetWeights();
    void SetPrice(double lollipopPrice, double chocolatePrice, double wafflesPrice, double drageePrice);
    GiftSet GetGiftSet();
}

// Builder for "Ласунка"
class EconomyGiftSetBuilder : IGiftSetBuilder
{
    private GiftSet giftSet = new GiftSet();

    public void SetName()
    {
        giftSet.Name = "Ласунка";
    }

    public void SetPrice(double lollipopPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        giftSet.Price = giftSet.LollipopsWeight * lollipopPrice +
                        giftSet.ChocolateWeight * chocolatePrice +
                        giftSet.WafflesWeight * wafflesPrice +
                        giftSet.DrageeWeight * drageePrice;
    }

    public void SetWeights()
    {
        giftSet.LollipopsWeight = 0.4;
        giftSet.ChocolateWeight = 0.3;
        giftSet.WafflesWeight = 0.6;
        giftSet.DrageeWeight = 0.2;
    }

    public GiftSet GetGiftSet()
    {
        return giftSet;
    }
}

// Builder for "Наминайко"
class StandardGiftSetBuilder : IGiftSetBuilder
{
    private GiftSet giftSet = new GiftSet();

    public void SetName()
    {
        giftSet.Name = "Наминайко";
    }

    public void SetPrice(double lollipopPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        giftSet.Price = giftSet.LollipopsWeight * lollipopPrice +
                        giftSet.ChocolateWeight * chocolatePrice +
                        giftSet.WafflesWeight * wafflesPrice +
                        giftSet.DrageeWeight * drageePrice;
    }

    public void SetWeights()
    {
        giftSet.LollipopsWeight = 0.5;
        giftSet.ChocolateWeight = 0.4;
        giftSet.WafflesWeight = 0.7;
        giftSet.DrageeWeight = 0.3;
    }

    public GiftSet GetGiftSet()
    {
        return giftSet;
    }
}

// Builder for "Пан коцький"
class PremiumGiftSetBuilder : IGiftSetBuilder
{
    private GiftSet giftSet = new GiftSet();

    public void SetName()
    {
        giftSet.Name = "Пан коцький";
    }

    public void SetPrice(double lollipopPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        giftSet.Price = giftSet.LollipopsWeight * lollipopPrice +
                        giftSet.ChocolateWeight * chocolatePrice +
                        giftSet.WafflesWeight * wafflesPrice +
                        giftSet.DrageeWeight * drageePrice;
    }

    public void SetWeights()
    {
        giftSet.LollipopsWeight = 0.6;
        giftSet.ChocolateWeight = 0.5;
        giftSet.WafflesWeight = 0.8;
        giftSet.DrageeWeight = 0.4;
    }

    public GiftSet GetGiftSet()
    {
        return giftSet;
    }
}

class Director
{
    private IGiftSetBuilder builder;

    public void SetBuilder(IGiftSetBuilder builder)
    {
        this.builder = builder;
    }

    public GiftSet ConstructGiftSet(double lollipopPrice, double chocolatePrice, double wafflesPrice, double drageePrice)
    {
        builder.SetName();
        builder.SetWeights();
        builder.SetPrice(lollipopPrice, chocolatePrice, wafflesPrice, drageePrice);
        return builder.GetGiftSet();
    }
}