using Application.Deadlines.Queries;
using Domain.DeadlineAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Api.Deadlines;

[Route("deadlines")]
public class DeadlinesController(ISender mediator) : ApiControllerBase(mediator)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetDeadlineQuery query = new(id!);

        ErrorOr<Deadline> result = await Mediator.Send(query);

        return result.Match(
            deadline => Ok(deadline.ToResponse()),
            errors => Problem(errors));
    }
}