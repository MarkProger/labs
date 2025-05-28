using System;
using System.Globalization;
using System.Threading;


Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

var bankHandler = new BankTransferHandler();
var wuHandler = new WesternUnionHandler();
var unistreamHandler = new UnistreamHandler();
var paypalHandler = new PayPalHandler();

bankHandler.SetNext(wuHandler);
wuHandler.SetNext(unistreamHandler);
unistreamHandler.SetNext(paypalHandler);

Console.Write("Enter recipient: ");
string recipient = Console.ReadLine();

Console.Write("Enter amount: ");
decimal amount = decimal.Parse(Console.ReadLine());

Console.Write("Enter method (Bank, WesternUnion, Unistream, PayPal): ");
string method = Console.ReadLine();

var request = new TransferRequest(recipient, amount, method);
bankHandler.Handle(request);

class TransferRequest
{
    public string Recipient { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; }

    public TransferRequest(string recipient, decimal amount, string method)
    {
        Recipient = recipient;
        Amount = amount;
        Method = method;
    }
}

abstract class TransferHandler
{
    protected TransferHandler NextHandler;

    public void SetNext(TransferHandler next)
    {
        NextHandler = next;
    }

    public void Handle(TransferRequest request)
    {
        if (CanHandle(request))
        {
            Process(request);
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(request);
        }
        else
        {
            Console.WriteLine("No available method to process the transfer.");
        }
    }

    protected abstract bool CanHandle(TransferRequest request);
    protected abstract void Process(TransferRequest request);
}

class BankTransferHandler : TransferHandler
{
    protected override bool CanHandle(TransferRequest request)
    {
        return request.Method == "Bank";
    }

    protected override void Process(TransferRequest request)
    {
        Console.WriteLine($"Bank transfer of {request.Amount:C} to {request.Recipient} completed.");
    }
}

class WesternUnionHandler : TransferHandler
{
    protected override bool CanHandle(TransferRequest request)
    {
        return request.Method == "WesternUnion";
    }

    protected override void Process(TransferRequest request)
    {
        Console.WriteLine($"Western Union transfer of {request.Amount:C} to {request.Recipient} completed.");
    }
}

class UnistreamHandler : TransferHandler
{
    protected override bool CanHandle(TransferRequest request)
    {
        return request.Method == "Unistream";
    }

    protected override void Process(TransferRequest request)
    {
        Console.WriteLine($"Unistream transfer of {request.Amount:C} to {request.Recipient} completed.");
    }
}

class PayPalHandler : TransferHandler
{
    protected override bool CanHandle(TransferRequest request)
    {
        return request.Method == "PayPal";
    }

    protected override void Process(TransferRequest request)
    {
        Console.WriteLine($"PayPal transfer of {request.Amount:C} to {request.Recipient} completed.");
    }
}
