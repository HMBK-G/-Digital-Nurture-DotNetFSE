using System; 

public class Computer
{
    public string CPU { get; }
    public string RAM { get; }
    public string Storage { get; }
    public bool HasGraphicsCard { get; }
    public bool HasWiFi { get; }

    private Computer(Builder builder)
    {
        CPU = builder.CPU;
        RAM = builder.RAM;
        Storage = builder.Storage;
        HasGraphicsCard = builder.HasGraphicsCard;
        HasWiFi = builder.HasWiFi;
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine($"Computer Specs: CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, GPU: {HasGraphicsCard}, WiFi: {HasWiFi}");
    }

    public class Builder
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }
        public bool HasGraphicsCard { get; private set; }
        public bool HasWiFi { get; private set; }

        public Builder(string cpu, string ram, string storage)
        {
            CPU = cpu;
            RAM = ram;
            Storage = storage;
        }

        public Builder SetGraphicsCard(bool hasGraphicsCard)
        {
            HasGraphicsCard = hasGraphicsCard;
            return this;
        }

        public Builder SetWiFi(bool hasWiFi)
        {
            HasWiFi = hasWiFi;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Computer basicComputer = new Computer.Builder("Intel i3", "8GB", "256GB SSD")
            .Build();

        Computer gamingComputer = new Computer.Builder("Intel i9", "32GB", "1TB SSD")
            .SetGraphicsCard(true)
            .SetWiFi(true)
            .Build();

        basicComputer.DisplayConfiguration();
        gamingComputer.DisplayConfiguration();
    }
}