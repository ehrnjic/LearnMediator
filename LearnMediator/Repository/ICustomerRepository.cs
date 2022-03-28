using LearnMediator.Models;

namespace LearnMediator.Repository;

public interface ICustomerRepository
{
    public List<Customer> GetAllCustomers();
    public Customer GetCustomerById(Guid id);
    public Customer CreateCustomer(Customer customer);
    public Customer UpdateCustomer(Customer customer);
    public Customer DeleteCustomer(Guid id);
}
