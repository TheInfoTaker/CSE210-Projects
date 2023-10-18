using System;
using System.Collections.Generic;

class Address
{
    private string StreetAddress { get; set; }
    private string City { get; set; }
    private string StateProvince { get; set; }
    private string Country { get; set; }
    
    public Address(string streetAddress, string city, string stateProvince,string country)
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
        return $"{StreetAddress}\n {City}, {StateProvince}\n{Country}";
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

    public Product(string name, int productId, decimal price, int quality)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = Quantity;
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

    public decimal CalculateProductTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice = product.CalculateProductTotalPrice();
        }

        if (Customer.IsInUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
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
        Address customerAddress = new Address("475 Bugg st","Thisplace", "NC", "USA");

        Customer customer = new Customer("Bill", customerAddress);

        Product product1 = new Product("Hat", 1, 10.99M, 2);
        Product product2 = new Product("Chicken", 2, 18.50M, 3);

        Order order1 = new Order(customer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Address nonUsaAddress = new Address("154 9th st", "ThePlace", "Camba", "Africa");

        Customer nonUsaCustomer = new Customer("John", nonUsaAddress);

        Product product3 = new Product("Nintendo DS", 3, 10.00M, 3);

        Order order2 = new Order(nonUsaCustomer);
        order2.AddProduct(product3);

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateProductTotalPrice():F2}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateProductTotalPrice():F2}\n");
    }
}
