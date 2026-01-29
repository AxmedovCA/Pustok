using Pustok.Business.Abstractions;

namespace Pustok.Business.Exceptions
{
    public class AlreadyExistException(string message = "This item is already exist") : Exception(message), IBaseExpetion
    {
        public int StatusCode { get; set; } = 409;
    }
}
