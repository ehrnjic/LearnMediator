using LearnMediator.DTOs;
using LearnMediator.Models;

namespace LearnMediator.Mappers;

public static class CustomerMapper
{
    public static CustomerDto ToCustomerDto(Customer customer)
    {
        return new CustomerDto(){ 
            Id = customer.Id,
            Name = customer.Name
        };
    }

    public static List<CustomerDto> ToCustomersDto(List<Customer> customers)
    {
        List<CustomerDto> customersDto = new List<CustomerDto>();
        foreach (Customer customer in customers)
        {
            customersDto.Add(ToCustomerDto(customer));
        }

        return customersDto;
    }

    public static Customer ToCustomer(CustomerDto customerDto)
    {
        return new Customer()
        {
            Name = customerDto.Name
        };
    }
}