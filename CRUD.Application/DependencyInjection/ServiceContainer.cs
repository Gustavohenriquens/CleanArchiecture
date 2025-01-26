using CRUD.Application.MappingImplementation;
using CRUD.Application.MappingInterface;
using CRUD.Application.UseCasaImplementation;
using CRUD.Application.UseCaseInterface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        // É uma interface usada no ASP.NET Core para configurar e registrar serviços para a injeção de dependência (DI - Dependency Injection). 
        // Basicamente, é onde você registra serviços, como controladores, repositórios, contextos de banco de dados, etc.
        public static IServiceCollection AddApplicationService
             (this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductMapper, ProductMapper>();
            return services;
        }
    }
}
