using LearnMediator.DTOs;
using LearnMediator.Mappers;
using LearnMediator.Repository;
using MediatR;

namespace LearnMediator.Commands;

public record CreateCustomerCommand : IRequest<CustomerDto>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepo;

    public CreateCustomerCommandHandler(ICustomerRepository repo)
    {
        _customerRepo = repo;
    }

    public Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // treba validirati prije upisa
        return Task.FromResult(
            CustomerMapper.ToCustomerDto(
                _customerRepo.CreateCustomer(CustomerMapper.ToCustomer(new CustomerDto()
                { Name = request.Name }))));
    }
}