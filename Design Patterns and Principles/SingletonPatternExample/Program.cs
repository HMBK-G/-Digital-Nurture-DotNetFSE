using System; 
using SingletonPatternExample.Services;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();   

        logger1.Log("Hello from logger 1!"); 
        logger2.Log("Hello from logger 2!");   
        if (logger1 == logger2)
        {
            Console.WriteLine("Success: Both the vars point to the same instance!");
        }

        else
        {
            Console.WriteLine("Failure: Oh noooh! Different instances exist.");
        }
    }

}