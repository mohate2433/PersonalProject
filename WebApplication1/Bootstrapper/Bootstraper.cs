using ApplicationService.Contracts.Contract;
using ApplicationService.Services;
using Domain.Contract;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Bootstrapper
{
    public class Bootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddDbContext<PersonDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
