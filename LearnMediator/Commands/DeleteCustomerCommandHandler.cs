using LearnMediator.DTOs;
using LearnMediator.Mappers;
using LearnMediator.Repository;
using MediatR;

namespace LearnMediator.Commands;

public record DeleteCustomerCommand(Guid id) : IRequest<CustomerDto>;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepo;

    public DeleteCustomerCommandHandler(ICustomerRepository repo)
    {
        _customerRepo = repo;
    }

    public Task<CustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(CustomerMapper.ToCustomerDto(_customerRepo.DeleteCustomer(request.id)));
    }
}