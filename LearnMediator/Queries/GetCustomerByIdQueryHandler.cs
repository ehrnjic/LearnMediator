using LearnMediator.DTOs;
using LearnMediator.Mappers;
using LearnMediator.Repository;
using MediatR;

namespace LearnMediator.QueryHandlers;

public record GetCustomersByIdQuery(Guid id) : IRequest<CustomerDto>;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomersByIdQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepo;

    public GetCustomerByIdQueryHandler(ICustomerRepository repo)
    {
        _customerRepo = repo;
    }

    public Task<CustomerDto> Handle(GetCustomersByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(CustomerMapper.ToCustomerDto(_customerRepo.GetCustomerById(request.id)));
    }
}