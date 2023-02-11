using ApplicationService.Contracts.Contract;
using ApplicationService.Services;
using Domain.Contract;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Bootstrapper
{
    public class Bootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<INoteRepository, NoteRepository>();


            services.AddDbContext<PersonalDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
