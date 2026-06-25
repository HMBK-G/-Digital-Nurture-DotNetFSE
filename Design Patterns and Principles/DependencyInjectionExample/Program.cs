using System;

namespace DependencyInjectionExample
{
    interface ICustomerRepository
    {
        string FindCustomerById(int id);
    }

    class CustomerRepositoryImpl : ICustomerRepository
    {
        public string FindCustomerById(int id)
        {
            return "Customer ID: " + id + ", Name: Hemambika";
        }
    }

    class CustomerService
    {
        private ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public void GetCustomer(int id)
        {
            Console.WriteLine(repository.FindCustomerById(id));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepositoryImpl();

            CustomerService service = new CustomerService(repository);

            service.GetCustomer(109);

            Console.ReadKey();
        }
    }
}

/*
Dependency Injection:
Dependency Injection is a design principle where an object receives its
dependencies from an external source instead of creating them itself.
Here, CustomerService depends on ICustomerRepository, and the dependency
is provided through the constructor (Constructor Injection). This makes
the code loosely coupled, flexible, and easier to test.
*/