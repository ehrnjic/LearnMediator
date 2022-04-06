using LearnMediator.Data;
using LearnMediator.Models;

namespace LearnMediator.Repository;

public class CustomerDbRepository : ICustomerRepository
{
    private readonly CustomerDbContext _dbContext;
    public CustomerDbRepository(CustomerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Customer CreateCustomer(Customer customer)
    {
        customer.Id = Guid.NewGuid();
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
        return customer;
    }

    public Customer DeleteCustomer(Guid id)
    {
        Customer? customer = _dbContext.Customers.FirstOrDefault(c => c.Id.Equals(id));
        if (customer == null)
        {
            throw new KeyNotFoundException(message: "Not found customer with id: " + id);
        }
        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
        return customer;
    }

    public List<Customer> GetAllCustomers()
    {
        return _dbContext.Customers.ToList();
    }

    public Customer GetCustomerById(Guid id)
    {
        Customer? customer = _dbContext.Customers.FirstOrDefault(c => c.Id.Equals(id));
        if (customer == null)
        {
            throw new KeyNotFoundException(message: "Not found customer with id: " + id);
        }

        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        Customer? currentCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id.Equals(customer.Id));
        if (currentCustomer == null)
        {
            throw new KeyNotFoundException(message: "Not found customer with id: " + customer.Id);
        }
        currentCustomer.Name = customer.Name;
        _dbContext.SaveChanges();
        return currentCustomer;
    }
}
