using Pustok.Business.Abstractions;

namespace Pustok.Business.Exceptions
{
    public class RegisterFailException(string message = "Registration failed") : Exception(message), IBaseExpetion
    {
        public int StatusCode { get; set; } = 400;
    }
}
