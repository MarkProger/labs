using System.Reflection.Metadata;


var document1 = new Document { Size = "A4", IsColor = false, PageCount = 10, Content = "Some text" };
var document2 = new Document { Size = "A4", IsColor = true, PageCount = 5, Content = "Color doc" };
var document3 = new Document { Size = "A1", IsColor = true, PageCount = 1, Content = "Large format" };

var manager = new PrintManager();

manager.PrintDocument(document1);
manager.PrintDocument(document2);
manager.PrintDocument(document3);

public interface IPrintStrategy
{
    void Print(Document document);
}

public class Document
{
    public string Size { get; set; }
    public bool IsColor { get; set; }
    public int PageCount { get; set; }
    public string Content { get; set; }
}

public class LaserPrinter : IPrintStrategy
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing with Laser Printer...");
        Console.WriteLine($"Pages: {document.PageCount}, Size: {document.Size}, Color: {document.IsColor}");
    }
}

public class ColorPrinter : IPrintStrategy
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing with Color Printer...");
        Console.WriteLine($"Pages: {document.PageCount}, Size: {document.Size}, Color: {document.IsColor}");
    }
}

public class PlotterPrinter : IPrintStrategy
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing with Plotter...");
        Console.WriteLine($"Pages: {document.PageCount}, Size: {document.Size}, Color: {document.IsColor}");
    }
}

public class PrintManager
{
    private IPrintStrategy _strategy;

    public void SetStrategy(Document doc)
    {
        // Вибір стратегії
        if (doc.Size == "A2" || doc.Size == "A1" || doc.Size == "A0")
        {
            _strategy = new PlotterPrinter();
        }
        else if (doc.IsColor)
        {
            _strategy = new ColorPrinter();
        }
        else
        {
            _strategy = new LaserPrinter();
        }
    }

    public void PrintDocument(Document doc)
    {
        SetStrategy(doc);
        _strategy.Print(doc);
    }
}