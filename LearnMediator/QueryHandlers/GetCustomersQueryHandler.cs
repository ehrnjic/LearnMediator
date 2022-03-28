using LearnMediator.DTOs;
using LearnMediator.Mappers;
using LearnMediator.Repository;
using MediatR;

namespace LearnMediator.QueryHandlers;

public record GetCustomersQuery : IRequest<List<CustomerDto>>;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepo;

    public GetCustomersQueryHandler(ICustomerRepository repo)
    {
        _customerRepo = repo;
    }

    public Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(CustomerMapper.ToCustomersDto(_customerRepo.GetAllCustomers()));
    }
}