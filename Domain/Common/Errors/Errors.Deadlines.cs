using System.Runtime.InteropServices.JavaScript;
using Domain.DeadlineAggregate.ValueObjects;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Deadlines
    {
        public static Error NotFound(DeadlineId id) => 
            Error.NotFound($"Deadline.{nameof(NotFound)}", $"Deadline with id '{id}' was not found");
    }
}