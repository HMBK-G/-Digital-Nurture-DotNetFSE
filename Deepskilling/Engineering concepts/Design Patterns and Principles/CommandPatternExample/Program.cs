using System;

namespace CommandPatternExample
{
    interface ICommand
    {
        void Execute();
    }

    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
    }

    class RemoteControl
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light();

            ICommand lightOn = new LightOnCommand(light);
            ICommand lightOff = new LightOffCommand(light);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(lightOn);
            remote.PressButton();

            remote.SetCommand(lightOff);
            remote.PressButton();

            Console.ReadKey();
        }
    }
}

/*
Command Pattern:
The Command Pattern encapsulates a request as an object, allowing
requests to be parameterized and executed independently. It separates
the object that invokes the operation (Invoker) from the object that
performs the operation (Receiver). Here, RemoteControl is the Invoker,
Light is the Receiver, and LightOnCommand/LightOffCommand are Commands.
*/