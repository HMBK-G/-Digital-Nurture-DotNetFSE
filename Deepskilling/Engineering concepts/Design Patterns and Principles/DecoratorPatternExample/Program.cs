using System;

namespace DecoratorPatternExample
{
    public interface INotifier
    {
        void Send();
    }

    public class EmailNotifier : INotifier
    {
        public void Send()
        {
            Console.WriteLine("Sending notification via Email");
        }
    }

    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier notifier;

        public NotifierDecorator(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public virtual void Send()
        {
            notifier.Send();
        }
    }

    public class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send()
        {
            base.Send();
            Console.WriteLine("Sending notification via SMS");
        }
    }

    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send()
        {
            base.Send();
            Console.WriteLine("Sending notification via Slack");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INotifier notifier = new EmailNotifier();

            notifier = new SMSNotifierDecorator(notifier);
            notifier = new SlackNotifierDecorator(notifier);

            notifier.Send();

            Console.ReadKey();
        }
    }
}