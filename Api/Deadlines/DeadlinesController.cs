using Application.Deadlines.Commands;
using Application.Deadlines.Queries;
using Contracts.Deadlines;
using Domain.DeadlineAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Deadlines;

[Authorize]
[Route("deadlines")]
public class DeadlinesController(ISender mediator) : ApiControllerBase(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateDeadlineRequest request)
    {
        CreateDeadlineCommand command = request.ToCommand();
        
        ErrorOr<Deadline> result = await Mediator.Send(command);

        return result.Match(
            deadline => Ok(deadline.ToResponse()),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetDeadlineQuery query = new(id!);

        ErrorOr<Deadline> result = await Mediator.Send(query);

        return result.Match(
            deadline => Ok(deadline.ToResponse()),
            errors => Problem(errors)
        );
    }
}