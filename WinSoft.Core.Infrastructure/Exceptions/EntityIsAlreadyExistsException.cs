namespace WinSoft.Core.Infrastructure.Exceptions
{
    public class EntityIsAlreadyExistsException : Exception
    {
        public EntityIsAlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
