using System;

namespace ProxyPatternExample
{
    interface IImage
    {
        void Display();
    }

    class RealImage : IImage
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromServer();
        }

        private void LoadFromServer()
        {
            Console.WriteLine("Loading " + fileName + " from remote server...");
        }

        public void Display()
        {
            Console.WriteLine("Displaying " + fileName);
        }
    }

    class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }

            realImage.Display();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("sample.jpg");

            Console.WriteLine("First Display:");
            image.Display();

            Console.WriteLine();

            Console.WriteLine("Second Display:");
            image.Display();

            Console.ReadKey();
        }
    }
}

/*
Proxy Pattern:
The Proxy Pattern provides a substitute object that controls access to another object.
Here, ProxyImage acts as a proxy for RealImage. The image is loaded only when it is
needed for the first time (lazy initialization), and the loaded object is reused
for later requests (caching).
*/