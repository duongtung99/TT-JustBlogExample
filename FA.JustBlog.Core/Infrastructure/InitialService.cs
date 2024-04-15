using FA.JustBlog.Core.Context;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FA.JustBlog.Core.Infrastructure
{
    public static class InitialService
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IJustBlogContext, JustBlogContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
