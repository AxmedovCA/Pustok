using Microsoft.Extensions.DependencyInjection;
using Pustok.Business.Services.Abstractions;
using Pustok.Business.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.ServiceRegistrations
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
        services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<IPositionService,PositionService>();
            services.AddScoped<ICloudinaryService,CloudinaryService>();

            services.AddAutoMapper(_ => { },typeof(BusinessServiceRegistration).Assembly);
        }
    }
}
