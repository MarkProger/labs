using System;
using System.Collections.Generic;


var fastFood = new FastFoodSystem();
var manager = new OrderManager();

var order1 = new Order("Бургер", 2);
var order2 = new Order("Картопля фрі", 1);

var addOrder1 = new AddOrderCommand(fastFood, order1);
var addOrder2 = new AddOrderCommand(fastFood, order2);
var removeOrder1 = new RemoveOrderCommand(fastFood, order1);

manager.ExecuteCommand(addOrder1);
manager.ExecuteCommand(addOrder2);

fastFood.ShowOrders();

manager.ExecuteCommand(removeOrder1);

fastFood.ShowOrders();

manager.UndoLastCommand();

fastFood.ShowOrders();

interface ICommand
{
    void Execute();
    void Undo();
}

class Order
{
    public string ItemName { get; }
    public int Quantity { get; }

    public Order(string itemName, int quantity)
    {
        ItemName = itemName;
        Quantity = quantity;
    }

    public override string ToString() => $"{Quantity}x {ItemName}";
}

class FastFoodSystem
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        orders.Add(order);
        Console.WriteLine($"Додано замовлення: {order}");
    }

    public void RemoveOrder(Order order)
    {
        if (orders.Remove(order))
            Console.WriteLine($"Видалено замовлення: {order}");
        else
            Console.WriteLine($"Замовлення не знайдено: {order}");
    }

    public void ShowOrders()
    {
        Console.WriteLine("\nПоточні замовлення:");
        if (orders.Count == 0)
            Console.WriteLine("Немає замовлень.");
        else
            orders.ForEach(o => Console.WriteLine($"  - {o}"));
    }
}

class AddOrderCommand : ICommand
{
    private FastFoodSystem system;
    private Order order;

    public AddOrderCommand(FastFoodSystem system, Order order)
    {
        this.system = system;
        this.order = order;
    }

    public void Execute() => system.AddOrder(order);
    public void Undo() => system.RemoveOrder(order);
}

class RemoveOrderCommand : ICommand
{
    private FastFoodSystem system;
    private Order order;

    public RemoveOrderCommand(FastFoodSystem system, Order order)
    {
        this.system = system;
        this.order = order;
    }

    public void Execute() => system.RemoveOrder(order);
    public void Undo() => system.AddOrder(order);
}

class OrderManager
{
    private Stack<ICommand> history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        history.Push(command);
    }

    public void UndoLastCommand()
    {
        if (history.Count > 0)
        {
            ICommand command = history.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Немає команд для скасування.");
        }
    }
}