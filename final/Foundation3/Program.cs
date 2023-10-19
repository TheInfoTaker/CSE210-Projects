using System;

class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

    class Event
    {
        protected string EventTitle { get; set; }
        protected string Description { get; set; }
        protected DateTime Date { get; set; }
        protected string Time { get; set; }
        protected Address EventAddress { get; set; }

        public Event (string eventTitle, string description, DateTime date, string time, Address address)
        {
            EventTitle = eventTitle;
            Description = description;
            Date = date;
            Time = time;
            EventAddress = address;
        }

        public string GenerateStandardMessage()
        {
            return $"Event Title: {EventTitle}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {EventAddress.GetFullAddress()}";
        }

        public string GenerateFullMessage()
        {
            return GenerateStandardMessage();
        }

        public string GenerateShortDescription()
        {
            return $"{GetType().Name}: {EventTitle} ({Date.ToShortDateString()})";
        }
    }

class Lecture : Event
{
    private string Speaker { get; set; }
    private int Capacity { get; set; }

    public Lecture(string eventTitle, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(eventTitle, description, date, time, address)
        {
            Speaker = speaker;
            Capacity = capacity;
        }

        public new string GenerateFullMessage()
        {
            return base.GenerateFullMessage() + $"\nSpeaker: {Speaker}\nCapacity: {Capacity}";
        }
}

class Reception : Event
{
    private string RsvpEmail { get; set; }

    public Reception(string eventTitle, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(eventTitle, description, date, time, address)
        {
            RsvpEmail = rsvpEmail;
        }

        public new string GenerateFullMessage()
        {
            return base.GenerateFullMessage() + $"\nRSVP Email: {RsvpEmail}";
        }
}

class OutdoorGathering : Event
{
    private string WeatherForecast { get; set; }
    public OutdoorGathering(string eventTitle, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(eventTitle, description, date, time, address)
        {
            WeatherForecast = weatherForecast;
        }

        public new string GenerateFullMessage()
        {
            return base.GenerateFullMessage() + $"\nWeather Forecast: {WeatherForecast}";
        }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("174 hollow", "King", "NC", "USA");
        Address address2 = new Address("824 Madison St", "Winston", "CA", "USA");
        Address address3 = new Address("864 Layton Dr", "Mayson", "MA", "USA");

        Event event1 = new Event("Event 1", "Description 1", DateTime.Now, "10:00 AM", address1);
        Lecture lecture1 = new Lecture("Lecture 1", "Lecture Description", DateTime.Now, "2:00 PM", address2, "speaker 1", 100);
        Reception reception1 = new Reception("Reception 1", "Reception Description", DateTime.Now, "6:00 PM", address3, "rsvp@example.com");
        OutdoorGathering gathering1 = new OutdoorGathering("Gathering 1", "Gathering Description", DateTime.Now, "4:00 PM", address1, "Rain");

        Console.WriteLine("Standard Messages:");
        Console.WriteLine(event1.GenerateStandardMessage());
        Console.WriteLine("\n");
        Console.WriteLine(lecture1.GenerateStandardMessage());
        Console.WriteLine("\n");
        Console.WriteLine(reception1.GenerateStandardMessage());
        Console.WriteLine("\n");
        Console.WriteLine(gathering1.GenerateStandardMessage());

        Console.WriteLine("\nFull Messages:");
        Console.WriteLine(event1.GenerateFullMessage());
        Console.WriteLine("\n");
        Console.WriteLine(lecture1.GenerateFullMessage());
        Console.WriteLine("\n");
        Console.WriteLine(reception1.GenerateFullMessage());
        Console.WriteLine("\n");
        Console.WriteLine(gathering1.GenerateFullMessage());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(event1.GenerateFullMessage());
        Console.WriteLine("\n");
        Console.WriteLine(lecture1.GenerateFullMessage());
        Console.WriteLine("\n");
        Console.WriteLine(reception1.GenerateFullMessage());
        Console.WriteLine("\n");
        Console.WriteLine(gathering1.GenerateFullMessage());
    }
}