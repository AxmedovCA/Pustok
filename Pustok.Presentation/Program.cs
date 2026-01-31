using Pustok.DataAccess.ServiceRegistrations;
using Pustok.Business.ServiceRegistrations;
using Pustok.Presentation.Middlewares;
using Pustok.DataAccess.Abstractions;

namespace Pustok.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddBusinessServices();
            var app = builder.Build();
            var scope =app.Services.CreateScope();
            var initalizer= scope.ServiceProvider.GetRequiredService<IContextInitalizer>(); 
            await initalizer.InitDatabaseAsync();
            app.UseMiddleware<GlobalExceptionHandler>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            await app.RunAsync();
        }
    }
}
