using Pustok.Business.Abstractions;
using Pustok.Business.Dtos.ResultDtos;

namespace Pustok.Presentation.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext  context) 
        {
            try
            {
            await _next(context);

            }
            catch (Exception ex)
            {
                ResultDto errorResult = new ResultDto()
                {
                    IsSucced = false,
                    Message = "Internal Server Error",
                    StatusCode = 500
                };
                if(ex is IBaseExpetion baseExpetion)
                {
                    errorResult.Message = ex.Message;
                    errorResult.StatusCode = baseExpetion.StatusCode;

                }
                context.Response.StatusCode= errorResult.StatusCode;
                await context.Response.WriteAsJsonAsync(errorResult);
                
            }
        }
    }
}
