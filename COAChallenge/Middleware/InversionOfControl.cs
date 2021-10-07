using COAChallenge.Repository;
using COAChallenge.Repository.Implement;
using COAChallenge.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COAChallenge.Middleware
{
    public static class InversionOfControl
    {
        public static IServiceCollection AddDependecis(this IServiceCollection services)
        {
            services.AddScoped<IUofW, UofW>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
