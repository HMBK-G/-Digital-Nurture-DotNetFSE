using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    interface IObserver
    {
        void Update(string stockName, double price);
    }

    interface IStock
    {
        void RegisterObserver(IObserver observer);
        void DeregisterObserver(IObserver observer);
        void NotifyObservers();
    }

    class StockMarket : IStock
    {
        private List<IObserver> observers = new List<IObserver>();
        private string stockName;
        private double price;

        public StockMarket(string stockName)
        {
            this.stockName = stockName;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(stockName, price);
            }
        }

        public void SetPrice(double newPrice)
        {
            price = newPrice;
            NotifyObservers();
        }
    }

    class MobileApp : IObserver
    {
        public void Update(string stockName, double price)
        {
            Console.WriteLine("Mobile App: " + stockName + " price updated to " + price);
        }
    }

    class WebApp : IObserver
    {
        public void Update(string stockName, double price)
        {
            Console.WriteLine("Web App: " + stockName + " price updated to " + price);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StockMarket stock = new StockMarket("CTS");

            IObserver mobile = new MobileApp();
            IObserver web = new WebApp();

            stock.RegisterObserver(mobile);
            stock.RegisterObserver(web);

            stock.SetPrice(3500);
            Console.WriteLine();

            stock.SetPrice(3600);

            Console.ReadKey();
        }
    }
}

/*
Observer Pattern:
The Observer Pattern defines a one-to-many relationship between objects.
When the state of one object (Subject) changes, all dependent objects
(Observers) are automatically notified and updated. Here, StockMarket
is the Subject, while MobileApp and WebApp are Observers that receive
stock price updates.
*/