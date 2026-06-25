using System;

namespace StrategyPatternExample
{
    interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Paid Rs." + amount + " using Credit Card");
        }
    }

    class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Paid Rs." + amount + " using PayPal");
        }
    }

    class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(double amount)
        {
            paymentStrategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext();

            context.SetStrategy(new CreditCardPayment());
            context.ExecutePayment(5000);

            context.SetStrategy(new PayPalPayment());
            context.ExecutePayment(3000);

            Console.ReadKey();
        }
    }
}

/*
Strategy Pattern:
The Strategy Pattern defines a family of algorithms and makes them
interchangeable at runtime. Instead of hardcoding a single behavior,
the Context uses different Strategy objects as needed. Here,
CreditCardPayment and PayPalPayment are strategies, while
PaymentContext selects and executes the chosen payment method.
*/


// The Strategy Pattern allows selecting different algorithms or behaviors at runtime without changing the client code.
