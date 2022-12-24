using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;DataBase=dbAPI2;Uid=root;Pwd=mudar@123")
                //SQL Server options => options.UseSQLServer("SQLEXPRESS2017; Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@123")
            );
        }
    }
}
