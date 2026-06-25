using System; 
public interface IPaymentProcessor
{
    void ProcessPayment(double amount);

}
public class PhonePeGateway
{
    public void InitialUPIPayment(double amount)
    {
        Console.WriteLine($"Processing ${amount} via PhonePe UPI" );
    }
}
public class GooglePayGateway
{

    public void ExecuteGPayTransaction(double amount)
    {
        Console.WriteLine($"Processing ${amount} via Google Pay.");
    }
}

public class PhonePeAdapter : IPaymentProcessor
{
    private readonly PhonePeGateway _phonePeGateway;

    public PhonePeAdapter(PhonePeGateway phonePeGateway)
    {
        _phonePeGateway = phonePeGateway;
    }

    public void ProcessPayment(double amount)
    {
        _phonePeGateway.InitialUPIPayment(amount);
    }
}

public class GooglePayAdapter : IPaymentProcessor
{
    private GooglePayGateway _googlePayGateway;

    public GooglePayAdapter(GooglePayGateway googlePayGateway)
    {
        _googlePayGateway = googlePayGateway;
    }

    public void ProcessPayment(double amount)
    {
        _googlePayGateway.ExecuteGPayTransaction(amount);
    }
}
class Program
{
    static void Main(string[] args)
    {
        PhonePeGateway phonePe = new PhonePeGateway();
        IPaymentProcessor phonePeProcessor = new PhonePeAdapter(phonePe);

        GooglePayGateway gpay = new GooglePayGateway();
        IPaymentProcessor gpayProcessor = new GooglePayAdapter(gpay);

        phonePeProcessor.ProcessPayment(150.00);
        gpayProcessor.ProcessPayment(500.00);
    }
}