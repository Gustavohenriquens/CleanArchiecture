using CRUD.Application.MappingImplementation;
using CRUD.Application.MappingInterface;
using CRUD.Domain.RepositoryInterface;
using CRUD.Infrastructure.DatabaseContext;
using CRUD.Infrastructure.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService
             (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(
                o => o.UseSqlServer(config.GetConnectionString("Default")));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
