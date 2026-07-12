using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "456 Moon Circle",
            "Phoenix",
            "Arizona",
            "USA"
        );
        Customer customer1 = new Customer("Mary Jane Smith", address1);
        Product product1 = new Product("Joos Juice 2L", "S012", 8, 215);
        Product product2 = new Product("Disposable Cups 100 Count", "A105", 3, 9);
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        Address address2 = new Address(
            "12093",
            "London",
            "England",
            "United Kingdom"
        );
        Customer customer2 = new Customer("David Tenant", address2);
        Product product3 = new Product("Flower Stickers 20 Count", "J025", 1, 3);
        Product product4 = new Product("Gem Stickers 20 Count", "J026", 1, 1);
        Product product5 = new Product("Fairy Stickers 20 Count", "J028", 1, 2);
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        List<Order> orders = new List<Order>
        {
            order1,
            order2
        };
        foreach (Order order in orders)
        {
            Console.WriteLine("PACKING LABEL");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("\nSHIPPING LABEL");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"\nTOTAL COST: ${order.CalculateTotalCost()}");
            Console.WriteLine(new string('-', 30));
        }
    }
}