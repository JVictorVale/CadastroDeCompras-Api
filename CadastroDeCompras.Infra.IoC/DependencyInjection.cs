using CadastroDeCompras.Application.Mappings;
using CadastroDeCompras.Application.Services;
using CadastroDeCompras.Application.Services.Interface;
using CadastroDeCompras.Domain.Repositories;
using CadastroDeCompras.Infra.Data.Context;
using CadastroDeCompras.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroDeCompras.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructre(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseMySql(ConfigurationExtensions.GetConnectionString("")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}