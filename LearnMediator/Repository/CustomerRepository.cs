using LearnMediator.Models;

namespace LearnMediator.Repository;

public class CustomerRepository : ICustomerRepository
{
    // Create list for seed
    private List<Customer> _customers = new List<Customer>();

    public CustomerRepository()
    {
        CreateCustomerFromSeed();
    }

    public void CreateCustomerFromSeed()
    {
        // Create Customers test seed
        _customers.Add(new Customer { Id = Guid.Parse("896b7515-e31b-4cdf-b824-250d884b25ed"), Name = "Adnan" });
        _customers.Add(new Customer { Id = Guid.Parse("18cc2218-9c7e-47a9-8f8f-8ca174880dbb"), Name = "Dzeva" });
        _customers.Add(new Customer { Id = Guid.Parse("8af59d6d-3308-45ec-a1d4-8e14cee6831c"), Name = "Zeljko" });
        _customers.Add(new Customer { Id = Guid.Parse("296763cd-1e0e-4f46-969a-f073a55cbf7e"), Name = "Nihad" });
        _customers.Add(new Customer { Id = Guid.Parse("296763cd-1e0e-4f46-969a-f073a55cbf7e"), Name = "Lejla" });
    }

    public List<Customer> GetAllCustomers()
    {
        return _customers;
    }

    public Customer GetCustomerById(Guid id)
    {
        Customer? customer = _customers.FirstOrDefault(c => c.Id.Equals(id));
        if (customer == null)
        {
            throw new KeyNotFoundException(message: "Not found customer with id: " + id);
        }

        return customer;
    }

    public Customer CreateCustomer(Customer customer)
    {
        customer.Id = Guid.NewGuid();
        _customers.Add(customer);
        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        Customer? currentCustomer = _customers.FirstOrDefault(c => c.Id.Equals(customer.Id));
        if (currentCustomer == null)
        {
            throw new KeyNotFoundException(message: "Not found customer with id: " + customer.Id);
        }
        currentCustomer.Name = customer.Name;
        return currentCustomer;
    }

    public Customer DeleteCustomer(Guid id)
    {
        Customer? customer = _customers.FirstOrDefault(c => c.Id.Equals(id));
        if (customer == null)
        {
            throw new KeyNotFoundException(message: "Not found customer with id: " + id);
        }
        _customers.Remove(customer);
        return customer;
    }
}