using LearnMediator.Commands;
using LearnMediator.DTOs;
using LearnMediator.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnMediator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<CustomerDto>> GetAll()
    {
        return await _mediator.Send(new GetCustomersQuery());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            CustomerDto res = await _mediator.Send(new GetCustomersByIdQuery(id));
            return Ok(res);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        CustomerDto res = await _mediator.Send(command);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        CustomerDto res = await _mediator.Send(command with { Id = id });
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        CustomerDto res = await _mediator.Send(new DeleteCustomerCommand(id));
        return Ok(res);
    }
}