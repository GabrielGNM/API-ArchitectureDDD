using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTest : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

        public ServiceProvider ServiceProvider { get; private set; }
        public dbTest()
        {
            var serviceColletion = new ServiceCollection();
            serviceColletion.AddDbContext<MyContext>(o =>
                o.UseMySql($"Persist Security Info=True;Server=local;Database={dataBaseName};User=root;Password=mudar@123"),
                    ServiceLifetime.Transient
            );
            ServiceProvider = serviceColletion.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }

}
