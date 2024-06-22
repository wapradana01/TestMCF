using Core.Services;
using DataAccess.SharedObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityConfig>(options => configuration.Bind(nameof(SecurityConfig), options));

            services.AddScoped<UserService>();
            services.AddScoped<TransactionService>();
            //services.AddHttpClient();

            return services;
        }
    }
}
