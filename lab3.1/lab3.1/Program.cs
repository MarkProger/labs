using System;


CustomerFactory factory;
ICustomer customer;

factory = new FullPaymentCustomerFactory();
customer = factory.CreateCustomer();
customer.GetFinalPrice();
customer.GetInsurenceScheme();
customer.GetServicePlan();

Console.WriteLine();

factory = new CreditCustomerFactory();
customer = factory.CreateCustomer();
customer.GetFinalPrice();
customer.GetInsurenceScheme();
customer.GetServicePlan();

Console.WriteLine();

factory = new InstallmentCustomerFactory();
customer = factory.CreateCustomer();
customer.GetFinalPrice();
customer.GetInsurenceScheme();
customer.GetServicePlan();

// Interface for customer
public interface ICustomer
{
    void GetFinalPrice();
    void GetInsurenceScheme();
    void GetServicePlan();
}

// Class for customers with full payment
public class FullPaymentCustomer : ICustomer
{
    public void GetFinalPrice()
    {
        Console.WriteLine("Фiнальна цiна для клiєнта з повною оплатою: знижка 5%.");
    }

    public void GetInsurenceScheme()
    {
        Console.WriteLine("Страховка для клiєнта з повною оплатою: Повне КАСКО.");
    }

    public void GetServicePlan()
    {
        Console.WriteLine("Гарантiйне обслуговування: 3 роки.");
    }
}

// Class for credit customers
public class CreditCustomer : ICustomer
{
    public void GetFinalPrice()
    {
        Console.WriteLine("Фiнальна цiна для клiєнта з кредитом: без знижок.");
    }

    public void GetInsurenceScheme()
    {
        Console.WriteLine("Страховка для клiєнта з кредитом: Обов'язкове страхування.");
    }

    public void GetServicePlan()
    {
        Console.WriteLine("Гарантiйне обслуговування: 2 роки.");
    }
}

// Class for installment customers
public class InstallmentCustomer : ICustomer
{
    public void GetFinalPrice()
    {
        Console.WriteLine("Фiнальна цiна для клiєнта з розтермiнуванням: знижка 2%.");
    }

    public void GetInsurenceScheme()
    {
        Console.WriteLine("Страховка для клiєнта з розтермiнуванням: Страхування при розтермiнуваннi.");
    }

    public void GetServicePlan()
    {
        Console.WriteLine("Гарантiйне обслуговування: 1 рiк.");
    }
}

// Class for clustomers creating
public abstract class CustomerFactory
{
    public abstract ICustomer CreateCustomer();
}

// Factory for fullpayment customers 
public class FullPaymentCustomerFactory : CustomerFactory
{
    public override ICustomer CreateCustomer()
    {
        return new FullPaymentCustomer();
    }
}

// Factory for credit customers
public class CreditCustomerFactory : CustomerFactory
{
    public override ICustomer CreateCustomer()
    {
        return new CreditCustomer();
    }
}

// Factory for installment customers
public class InstallmentCustomerFactory : CustomerFactory
{
    public override ICustomer CreateCustomer()
    {
        return new InstallmentCustomer();
    }
}
