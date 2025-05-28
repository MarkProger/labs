using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

Console.OutputEncoding = System.Text.Encoding.UTF8;
List<string> products = new List<string> { "iPhone 15", "Samsung Galaxy", "Xiaomi Redmi" };

ChromeOptions options = new ChromeOptions();
options.AddArgument("--start-maximized");

using (IWebDriver driver = new ChromeDriver(options))
{
    foreach (string product in products)
    {
        Console.WriteLine($"Шукаємо: {product}");

        driver.Navigate().GoToUrl("https://rozetka.com.ua");

        Thread.Sleep(3000);

        var searchBox = driver.FindElement(By.Name("search"));
        searchBox.Clear();
        searchBox.SendKeys(product);
        searchBox.SendKeys(Keys.Enter);

        Thread.Sleep(4000);

        try
        {
            var priceElement = driver.FindElement(By.CssSelector("span.goods-tile__price-value"));
            Console.WriteLine($"Ціна: {priceElement.Text} грн\n");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Ціну не знайдено.\n");
        }
    }
}

Console.WriteLine("Готово!");

