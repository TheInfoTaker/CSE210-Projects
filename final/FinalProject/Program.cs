using System;
using System.Collections.Generic;

class Address
{
    private string StreetAddress { get; set; }
    private string City { get; set; }
    private string StateProvince { get; set; }
    private string Country { get; set; }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country == "USA";
    }

    public string GetAddressString()
    {
        return $"{StreetAddress}\n{City}, {StateProvince}\n{Country}";
    }
}

class Customer
{
    private string Name { get; set; }
    private Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }

    public string GetCustomerInfo()
    {
        return $"Customer Name: {Name}\nAddress:\n{Address.GetAddressString()}";
    }
}

class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    private decimal Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal CalculateProductTotalPrice()
    {
        return Price * Quantity;
    }
}

class Order
{
    private List<Product> Products { get; set; }
    private Customer Customer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.CalculateProductTotalPrice();
        }

        if (Customer.IsInUSA())
        {
            totalPrice += 5; // Shipping cost for USA
        }
        else
        {
            totalPrice += 35; // Shipping cost for non-USA
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in Products)
        {
            packingLabel += $"{product.Name} (Product ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += Customer.GetCustomerInfo();
        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an address
        Address customerAddress = new Address("123 Main St", "Anytown", "CA", "USA");

        // Create a customer
        Customer customer = new Customer("John Doe", customerAddress);

        // Create products
        Product product1 = new Product("Widget", 1, 10.99M, 2);
        Product product2 = new Product("Gadget", 2, 15.50M, 1);
        
        // Create an order for the first customer
        Order order1 = new Order(customer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Create an address for a non-USA customer
        Address nonUsaAddress = new Address("456 Elm St", "Othercity", "Ontario", "Canada");

        // Create a non-USA customer
        Customer nonUsaCustomer = new Customer("Jane Smith", nonUsaAddress);

        // Create more products
        Product product3 = new Product("Thingamajig", 3, 8.99M, 3);

        // Create an order for the non-USA customer
        Order order2 = new Order(nonUsaCustomer);
        order2.AddProduct(product3);

        // Calculate and display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}