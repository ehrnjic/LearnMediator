using LearnMediator.DTOs;
using LearnMediator.Mappers;
using LearnMediator.Models;
using LearnMediator.Repository;
using MediatR;

namespace LearnMediator.Commands;

public record UpdateCustomerCommand : IRequest<CustomerDto>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepo;

    public UpdateCustomerCommandHandler(ICustomerRepository repo)
    {
        _customerRepo = repo;
    }

    public Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = new Customer()
        {
            Id = request.Id,
            Name = request.Name
        };

        return Task.FromResult(CustomerMapper.ToCustomerDto(_customerRepo.UpdateCustomer(customer)));
    }
}