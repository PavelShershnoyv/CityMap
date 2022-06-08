namespace InteractiveMap.Application.Common.Exceptions;

public class ForbiddenException : ApplicationException
{
    public ForbiddenException() : base() { }

    public ForbiddenException(string userId, string name, object key)
        : base($"User with id {userId} does not have access to entity {name} [{key}]") { }
}
